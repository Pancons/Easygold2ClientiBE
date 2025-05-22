using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities;
using EasyGold.API.Services.Interfaces;
using BCrypt.Net;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Models;

namespace EasyGold.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AutenticazioneController : ControllerBase
    {
        private readonly IUtenteService _utenteService;
        private readonly IConfiguration _configuration;

        public AutenticazioneController(IUtenteService utenteService, IConfiguration configuration)
        {
            _utenteService = utenteService;
            _configuration = configuration;
        }


        /// <summary>
        /// Esegue il login e restituisce un token JWT.
        /// </summary>
        /// <param name="request">Credenziali di accesso</param>
        /// <returns>Token JWT</returns>
        /// <response code="200">Login effettuato con successo</response>
        /// <response code="401">Credenziali non valide</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(BaseResponse<UtenteDTO>), StatusCodes.Status200OK)] // ✅ Successo: Token JWT
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)] // ✅ Username/password mancanti
        [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)] // ✅ Credenziali non valide
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)] // ✅ Errore interno
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest(new { error = "Username e password sono obbligatori" });

            try
            {
                var user = await _utenteService.AuthenticateAsync(request.Username, request.Password);
                if (user == null)
                {
                    return Unauthorized(new { error = "Credenziali non valide" });
                }

                // Controllo se la chiave segreta è null
                var secretKey = _configuration["Jwt:Secret"];
                if (string.IsNullOrEmpty(secretKey))
                {
                    return StatusCode(500, new { error = "Errore interno: Secret JWT non configurato" });
                }

                var tokenString = await _utenteService.CreateToken(user, secretKey);

                return Ok(new
                {
                    user = user,
                    token = tokenString
                });
            }
            catch (Exception ex)
            {
                // 🔹 LOGGARE L'ERRORE CON DETTAGLI
                Console.WriteLine($"Errore durante il login: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, new { error = "Errore interno del server", details = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint per il refresh del token JWT (quando l'utente clicca "Continua con Easygold").
        /// </summary>
        /// <returns>Nuovo token JWT</returns>
        /// <response code="200">Token rinnovato con successo</response>
        /// <response code="401">Utente non autenticato o accesso non consentito</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("refresh")]
        [Authorize]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            try
            {
                var username = User.Identity?.Name;
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (string.IsNullOrEmpty(username))
                    return Unauthorized(new { error = "Utente non autenticato" });

                var user = await _utenteService.UsernameExist(username);
                if (user == null)
                    return Unauthorized(new { error = "Utente non trovato" });

                var secretKey = _configuration["Jwt:Secret"];
                if (string.IsNullOrEmpty(secretKey))
                    return StatusCode(500, new { error = "Errore interno: Secret JWT non configurato" });

                var tokenString = await _utenteService.CreateToken(username, userRole, secretKey, refreshTokenRequest.LanguageId);

                return Ok(new
                {
                    token = tokenString
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il refresh token: {ex.Message}");
                return StatusCode(500, new { error = "Errore interno del server", details = ex.Message });
            }
        }


        public class LoginRequest
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }

        public class RefreshTokenRequest
        {
            public string? LanguageId { get; set; }
        }
    }
}