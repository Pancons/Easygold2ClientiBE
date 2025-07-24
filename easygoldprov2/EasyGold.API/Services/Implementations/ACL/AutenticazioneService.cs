using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.API.Utility;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Implementations.ACL
{
    public class AutenticazioneService : IAutenticazioneService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ISessioniEasyGoldService _sessionService; 

        public AutenticazioneService(ApplicationDbContext context, IConfiguration configuration,ISessioniEasyGoldService sessionService )
        {
            _context = context;
            _configuration = configuration;
            _sessionService = sessionService;
        }

        public async Task<ObjectResult> LoginAsync(string username, string password, string subdomain)
        {
            var connectionString = await GetConnectionStringForSubdomainAsync(subdomain);
            _context.Database.SetConnectionString(connectionString);

            var user = await _context.Utenti
                .Include(u => u.PwUtenti)
                .FirstOrDefaultAsync(u => u.Ute_NomeUtente == username);

            var passwordHash = user?.PwUtenti.FirstOrDefault()?.Utp_PwUtente;

            if (user == null || string.IsNullOrEmpty(passwordHash) || !BCrypt.Net.BCrypt.Verify(password, passwordHash))
                return new ObjectResult(new { error = "Credenziali non valide" }) { StatusCode = 401 };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Ute_IDUtente.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwt = GenerateJwtToken(claims, _configuration, SecurityAlgorithms.RsaSha256);
            var refreshToken = GenerateSecureToken();

            user.RefreshTokens.Add(new DbRefreshToken
            {
                Token = refreshToken,
                Expires = DateTime.UtcNow.AddDays(30)
            });

                // Crea una nuova sessione al login
            var sessionDto = new SessioniEasyGoldDTO
            {
                // Sse_IDCliente = user.Ute_IDCliente, chiedere a Fabio come comportarsi
                Sse_IDUtente = user.Ute_IDAuto,
                Sse_DataLogin = DateTime.UtcNow,
                Sse_SesScaduta = false
            };

            await _sessionService.AddAsync(sessionDto);

            await _context.SaveChangesAsync();

            return new ObjectResult(new { accessToken = jwt, refreshToken })
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<ObjectResult> RefreshTokenAsync(string refreshToken)
        {
            var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.IsActive);
            if (storedToken == null)
                return new ObjectResult(new { error = "Token non valido" }) { StatusCode = 401 };

            var userId = storedToken.UserId;

            var user = await _context.Utenti
                .FirstOrDefaultAsync(u => u.Ute_IDAuto == userId);

            if (user == null)
                return new ObjectResult(new { error = "Utente non trovato" }) { StatusCode = 404 };

            storedToken.Revoke();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Ute_IDUtente.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var newJwt = GenerateJwtToken(claims, _configuration, SecurityAlgorithms.RsaSha256);
            var newRefreshToken = GenerateSecureToken();

            await _context.RefreshTokens.AddAsync(new DbRefreshToken
            {
                UserId = userId,
                Token = newRefreshToken,
                Expires = DateTime.UtcNow.AddDays(30)
            });

            await _context.SaveChangesAsync();

            return new ObjectResult(new { accessToken = newJwt, refreshToken = newRefreshToken })
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task LogoutAsync(int userId)
        {

            // Distruggi la sessione al logout
            var session = await _context.SessioniEasyGold
                .FirstOrDefaultAsync(s => s.Sse_IDUtente == userId && !s.Sse_SesScaduta);

            if (session != null)
            {
                await _sessionService.EndSessionAsync(session.Sse_IDAuto);
            }

            var tokens = _context.RefreshTokens.Where(rt => rt.UserId == userId && rt.IsActive);
            foreach (var token in tokens)
            {
                token.Revoke();
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _context.Utenti
                .Include(u => u.PwUtenti)
                .FirstOrDefaultAsync(u => u.Ute_IDAuto == userId);

            var currentHash = user?.PwUtenti.FirstOrDefault()?.Utp_PwUtente;

            if (user == null || string.IsNullOrEmpty(currentHash) || !BCrypt.Net.BCrypt.Verify(oldPassword, currentHash))
                return false;

            var pwEntity = user.PwUtenti.FirstOrDefault();
            if (pwEntity != null)
            {
                pwEntity.Utp_PwUtente = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            await RevokeUserTokensAsync(userId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ObjectResult> ForgotPasswordAsync(string email)
        {
            var user = await _context.Utenti.FirstOrDefaultAsync(u => u.Ute_Email == email);
            if (user == null)
            {
                return new ObjectResult(new { message = "Se l'account esiste, riceverai un'email per resettare la password." })
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }

            var resetToken = GenerateSecureToken();
            user.Ute_PasswordResetToken = resetToken;
            user.Ute_ResetTokenExpiry = DateTime.UtcNow.AddHours(1);
            await _context.SaveChangesAsync();

            var resetLink = $"{_configuration["AppSettings:FrontendUrl"]}/reset-password?token={resetToken}";
            EmailUtility.SendPasswordResetEmail(user.Ute_Email, resetLink);

            return new ObjectResult(new { message = "Se l'account esiste, riceverai un'email per resettare la password." })
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<ObjectResult> ResetPasswordAsync(string token, string newPassword)
        {
            var user = await _context.Utenti.FirstOrDefaultAsync(u =>
                u.Ute_PasswordResetToken == token &&
                u.Ute_ResetTokenExpiry > DateTime.UtcNow);

            if (user == null)
            {
                return new ObjectResult(new { error = "Token non valido o scaduto" })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var pwEntity = user.PwUtenti.FirstOrDefault();
            if (pwEntity != null)
            {
                pwEntity.Utp_PwUtente = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            user.Ute_PasswordResetToken = null;
            user.Ute_ResetTokenExpiry = null;

            await RevokeUserTokensAsync(user.Ute_IDAuto);
            await _context.SaveChangesAsync();

            return new ObjectResult(new { message = "Password resettata con successo" })
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public static string GenerateJwtToken(IEnumerable<Claim> claims, IConfiguration configuration, string algorithm)
        {
            var key = Convert.FromBase64String(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string GenerateSecureToken(int length = 64)
        {
            var byteLength = length / 2;
            var randomBytes = new byte[byteLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return BitConverter.ToString(randomBytes).Replace("-", "").ToLowerInvariant();
        }

        private async Task<string> GetConnectionStringForSubdomainAsync(string subdomain)
        {
            // TODO: Recupera la connessione dal subdominio
            return await Task.FromResult("your-connection-string");
        }

        private async Task RevokeUserTokensAsync(int userId)
        {
            var tokens = _context.RefreshTokens.Where(t => t.UserId == userId && t.IsActive);
            foreach (var token in tokens)
            {
                token.Revoke();
            }
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SetLanguageInRefreshTokenAsync(string token, string language)
        {
            var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token && rt.IsActive);
            if (storedToken == null)
            {
                return false;
            }

            storedToken.Language = language;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetStoreInRefreshTokenAsync(string token, int storeId)
        {
            var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token && rt.IsActive);
            if (storedToken == null)
            {
                return false;
            }

            storedToken.StoreId = storeId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task EndSessionOnTokenExpiryAsync(int userId)
        {
            await _sessionService.EndSessionOnTokenExpiryAsync(userId);
        }
        
    }
}
