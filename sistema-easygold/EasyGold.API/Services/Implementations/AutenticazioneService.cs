using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models.Entities;
using EasyGold.API.Services;
using EasyGold.API.Infrastructure;
using BCrypt.Net;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Services.Implementations
{
    public class AutenticazioneService : IAutenticazioneService
    {
        private readonly ApplicationDbContext _context;

        public AutenticazioneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DbUtente> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Utenti.FirstOrDefaultAsync(u => u.Ute_NomeUtente == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Ute_Password))
                return null;

            return user;
        }

        public async Task<bool> RegisterUserAsync(string username, string password, int tipoAbilitazione)
        {
            if (await _context.Utenti.AnyAsync(u => u.Ute_NomeUtente == username))
                return false; // L'utente esiste già

            var newUser = new DbUtente
            {
                Ute_NomeUtente = username,
                Ute_Password = BCrypt.Net.BCrypt.HashPassword(password), // Hash della password
                Ute_IDRuolo = tipoAbilitazione,
                Ute_Bloccato = false,
                Ute_Nota = "Nuovo utente"
            };

            _context.Utenti.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
