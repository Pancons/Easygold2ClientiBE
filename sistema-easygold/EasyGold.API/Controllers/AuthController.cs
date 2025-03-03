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

namespace EasyGold.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
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
        /// <response code="401">Credenziali non valide</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest(new { error = "Username e password sono obbligatori" });

            var user = await _userService.AuthenticateAsync(request.Username, request.Password);
            if (user == null)
                return Unauthorized(new { error = "Credenziali non valide" });

            // Generazione del token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Ute_NomeUtente),
                    new Claim(ClaimTypes.Role, user.Ute_IDRuolo.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                user = new { user.Ute_IDUtente, user.Ute_NomeUtente, user.Ute_IDRuolo },
                token = tokenString
            });
        }


        /// <summary>
        /// Esegue il logout dell'utente.
        /// </summary>
        /// <returns>Conferma del logout</returns>
        /// <response code="200">Logout effettuato con successo</response>
        /// <response code="500">Errore interno durante il logout</response>
        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Logout()
        {
            try
            {
                return Ok(new { success = true, message = "Logout effettuato con successo" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore durante il logout", details = ex.Message });
            }
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
