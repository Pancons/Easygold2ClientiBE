using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using EasyGold.API.Infrastructure;
using BCrypt.Net;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    /// <summary>
    /// Servizio per autenticazione e gestione utenti.
    /// </summary>
    public class AutenticazioneService : IAutenticazioneService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AutenticazioneService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Autentica un utente tramite username e password.
        /// </summary>
        /// <param name="username">Nome utente</param>
        /// <param name="password">Password in chiaro</param>
        /// <returns>Utente autenticato o null</returns>
        public async Task<DbUtente> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Utenti.FirstOrDefaultAsync(u => u.Ute_NomeUtente == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Ute_Password))
                return null;

            return user;
        }

        /// <summary>
        /// Registra un nuovo utente.
        /// </summary>
        /// <param name="username">Nome utente</param>
        /// <param name="password">Password in chiaro</param>
        /// <param name="tipoAbilitazione">ID ruolo</param>
        /// <returns>True se registrazione avvenuta, false se utente già esistente</returns>
        public async Task<bool> RegisterUserAsync(string username, string password, int tipoAbilitazione)
        {
            if (await _context.Utenti.AnyAsync(u => u.Ute_NomeUtente == username))
                return false; // L'utente esiste già

            var newUser = new DbUtente
            {
                Ute_NomeUtente = username,
                Ute_Password = BCrypt.Net.BCrypt.HashPassword(password),
                Ute_IDRuolo = tipoAbilitazione,
                Ute_Bloccato = false,
                Ute_Nota = "Nuovo utente"
            };

            _context.Utenti.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Recupera la durata del token JWT (in minuti) dalla configurazione.
        /// Prima cerca in DB, poi in appsettings, infine default 60.
        /// </summary>
        public async Task<int> GetTokenExpiryMinutesAsync()
        {
            var config = await _context.Configurazioni
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Sys_NomeCampo == "JwtTokenExpiryMinutes");
            if (config != null && int.TryParse(config.Sys_Valore, out int minutes) && minutes > 0)
                return minutes;

            if (int.TryParse(_configuration["Jwt:ExpiryMinutes"], out int configMinutes) && configMinutes > 0)
                return configMinutes;

            return 60;
        }

        /// <summary>
        /// Verifica che la richiesta provenga dal Front End Easygold Web 2.0.
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns>True se la richiesta proviene dal frontend Easygold Web 2.0</returns>
        public bool IsRequestFromEasygoldFrontend(HttpRequest request)
        {
            var clientHeader = request.Headers["X-Easygold-Client"].FirstOrDefault();
            return clientHeader == "Web2.0";
        }
    }
}
