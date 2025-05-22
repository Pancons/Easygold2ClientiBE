using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models;
using EasyGold.API.Models.Utenti;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Allegati;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace EasyGold.API.Services.Implementations
{
    public class UtenteService : IUtenteService
    {
        private readonly IUtenteRepository _utenteRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public UtenteService(IUtenteRepository utenteRepository, IMapper mapper, IConfiguration configuration)
        {
            _utenteRepository = utenteRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<BaseListResponse<UtenteDTO>> GetUsersListAsync(UtentiListRequest filter)
        {
            var (utentiData, total) = await _utenteRepository.GetUsersListAsync(filter);
            return new BaseListResponse<UtenteDTO>
            {
                results = _mapper.Map<IEnumerable<UtenteDTO>>(utentiData).ToList(),  // ? Mappa automaticamente senza "N/A"
                total = total
            };
        }

        public async Task<UtenteDTO> GetUserByIdAsync(int id)
        {
            var utenteDettaglioDto = await _utenteRepository.GetUserByIdAsync(id);
            return _mapper.Map<UtenteDTO>(utenteDettaglioDto);
        }

        public async Task<bool> UsernameExist(string username)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(username))
                result = await _utenteRepository.UsernameExist(username);
            return result;
        }

        public async Task<UtenteDTO> AddAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = _mapper.Map<DbUtente>(utenteDettaglioDto);

            // In fase di inserimento di un nuovo utente, la password viene inizializzata con "password"
            // e criptata
            utente.Ute_Password = CryptPassword("password");

            await _utenteRepository.AddAsync(utente);
            return await GetUserByIdAsync(utente.Ute_IDUtente);
        }

        public async Task<UtenteDTO> UpdateAsync(UtenteDTO utenteDettaglioDto)
        {
            var utente = await _utenteRepository.GetUserByIdAsync((int)utenteDettaglioDto.Ute_IDUtente);
            utente = _mapper.Map(utenteDettaglioDto, utente);
            await _utenteRepository.UpdateAsync(utente);
            return await GetUserByIdAsync((int)utenteDettaglioDto.Ute_IDUtente);
        }

        public async Task DeleteAsync(int id)
        {
            await _utenteRepository.DeleteAsync(id);
        }

        public async Task<bool> ChangePassword(PasswordDTO passwordDto)
        {
            bool result = false;

            var utente = await _utenteRepository.GetUserByIdAsync(passwordDto.Ute_IDUtente);
            if (utente != null)
            {
                utente.Ute_Password = CryptPassword(passwordDto.Ute_NewPassword);
                await _utenteRepository.UpdateAsync(utente);

                result = true;
            }
            return result;
        }

        public async Task<UtenteDTO> AuthenticateAsync(string username, string password)
        {
            var user = await _utenteRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifyPassword(password, user.Ute_Password))
                return null;

            return _mapper.Map<UtenteDTO>(user);
        }

        public async Task<string> CreateToken(UtenteDTO user, string secretKey, string languageId = "IT")
        {
            return await CreateToken(user.Ute_NomeUtente, user.Ute_IDRuolo.ToString(), secretKey, languageId);
        }

        public async Task<string> CreateToken(string username, string userRole, string secretKey, string languageId = "IT")
        {
            languageId = languageId ?? "IT";

            // Generazione del token JWT
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, userRole),
                    new Claim("Language", languageId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(GetTokenExpiryMinutesAsync()),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string CryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }

        /// <summary>
        /// Recupera la durata del token JWT (in minuti) dalla configurazione.
        /// Prima cerca in DB, poi in appsettings, infine default 60.
        /// </summary>
        private int GetTokenExpiryMinutesAsync()
        {
            if (int.TryParse(_configuration["Jwt:ExpiryMinutes"], out int configMinutes) && configMinutes > 0)
                return configMinutes;

            return 60;
        }
    }
}