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
using BCrypt.Net;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dell'autenticazione e del refresh del token JWT.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticazioneController : ControllerBase
    {
        private readonly IAutenticazioneService _userService;
        private readonly IConfiguration _configuration;

        public AutenticazioneController(IAutenticazioneService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        /// <summary>
        /// Esegue il login e restituisce un token JWT.
        /// </summary>
        /// <param name="request">Credenziali di accesso</param>
        /// <returns>Token JWT</returns>
        /// <response code="200">Login effettuato con successo</response>
        /// <response code="400">Username/password mancanti</response>
        /// <response code="401">Credenziali non valide o accesso non consentito</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!_userService.IsRequestFromEasygoldFrontend(Request))
                return Unauthorized(new { error = "Accesso consentito solo dal Front End Easygold Web 2.0" });

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest(new { error = "Username e password sono obbligatori" });
            try
            {
                var user = await _userService.AuthenticateAsync(request.Username, request.Password);
                if (user == null)
                    return Unauthorized(new { error = "Credenziali non valide" });

                var secretKey = _configuration["Jwt:Secret"];
                if (string.IsNullOrEmpty(secretKey))
                    return StatusCode(500, new { error = "Errore interno: Secret JWT non configurato" });

                int expiryMinutes = await _userService.GetTokenExpiryMinutesAsync();

                var key = Encoding.UTF8.GetBytes(secretKey);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Ute_NomeUtente),
                        new Claim(ClaimTypes.Role, user.Ute_IDRuolo.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new
                {
                    user = new { user.Ute_IDUtente, user.Ute_NomeUtente, user.Ute_IDRuolo },
                    token = tokenString,
                    expiresInSeconds = expiryMinutes * 60
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il login: {ex.Message}");
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
        public async Task<IActionResult> RefreshToken()
        {
            if (!_userService.IsRequestFromEasygoldFrontend(Request))
                return Unauthorized(new { error = "Accesso consentito solo dal Front End Easygold Web 2.0" });

            try
            {
                var username = User.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                    return Unauthorized(new { error = "Utente non autenticato" });

                var user = await _userService.AuthenticateAsync(username, null);
                if (user == null)
                    return Unauthorized(new { error = "Utente non trovato" });

                var secretKey = _configuration["Jwt:Secret"];
                if (string.IsNullOrEmpty(secretKey))
                    return StatusCode(500, new { error = "Errore interno: Secret JWT non configurato" });

                int expiryMinutes = await _userService.GetTokenExpiryMinutesAsync();

                var key = Encoding.UTF8.GetBytes(secretKey);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Ute_NomeUtente),
                        new Claim(ClaimTypes.Role, user.Ute_IDRuolo.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new
                {
                    token = tokenString,
                    expiresInSeconds = expiryMinutes * 60
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il refresh token: {ex.Message}");
                return StatusCode(500, new { error = "Errore interno del server", details = ex.Message });
            }
        }

        /// <summary>
        /// Modello per la richiesta di login.
        /// </summary>
        public class LoginRequest
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }
    }
}
