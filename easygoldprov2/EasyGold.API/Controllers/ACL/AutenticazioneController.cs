using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Services.Implementations.ACL;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;


namespace EasyGold.API.Controllers.ACL
{
    [ApiController]
    [Route("api/auth")]
    public class AutenticazioneController : ControllerBase
    {
        private readonly IAutenticazioneService _authService;

        public AutenticazioneController(IAutenticazioneService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Subdomain))
            {
                return BadRequest(new { error = "Username, password e subdomain sono obbligatori" });
            }

            var response = await _authService.LoginAsync(request.Username, request.Password, request.Subdomain);
            return StatusCode((int)response.StatusCode, response.Value);
        }

        [HttpPost("refresh")]
        [Authorize]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized(new { error = "Nessun refresh token fornito" });
            }

            var response = await _authService.RefreshTokenAsync(refreshToken);
            return StatusCode((int)response.StatusCode, response.Value);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { error = "Utente non autenticato" });
            }

            await _authService.LogoutAsync(int.Parse(userId));
            return Ok(new { message = "Logout effettuato con successo" });
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = "Dati non validi" });
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { error = "Utente non autenticato" });
            }

            var result = await _authService.ChangePasswordAsync(int.Parse(userId), request.OldPassword, request.NewPassword);
            if (!result)
            {
                return BadRequest(new { error = "Cambio password fallito" });
            }

            return Ok(new { message = "Password aggiornata con successo" });
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var response = await _authService.ForgotPasswordAsync(request.Email);
            return StatusCode((int)response.StatusCode, response.Value);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = await _authService.ResetPasswordAsync(request.Token, request.NewPassword);
            return StatusCode((int)response.StatusCode, response.Value);
        }

        [HttpPost("set-language")]
        [Authorize]
        public async Task<IActionResult> SetLanguage([FromBody] LanguageRequest request)
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized(new { error = "Nessun refresh token fornito" });
            }

            var result = await _authService.SetLanguageInRefreshTokenAsync(refreshToken, request.Language);
            if (!result)
            {
                return BadRequest(new { error = "Impostazione della lingua fallita" });
            }

            return Ok(new { message = "Lingua aggiornata nel token con successo" });
        }

        [HttpPost("set-store")]
        [Authorize]
        public async Task<IActionResult> SetStore([FromBody] StoreRequest request)
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized(new { error = "Nessun refresh token fornito" });
            }

            var result = await _authService.SetStoreInRefreshTokenAsync(refreshToken, request.StoreId);
            if (!result)
            {
                return BadRequest(new { error = "Impostazione del negozio fallita" });
            }

            return Ok(new { message = "Negozio aggiornato nel token con successo" });
        }


    }


    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Subdomain { get; set; }
    }

    public class ChangePasswordRequest
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }

  
     public class ForgotPasswordRequest
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public class ResetPasswordRequest
        {
            [Required]
            public string Token { get; set; }

            [Required]
            public string NewPassword { get; set; }
        }

        public class LanguageRequest
        {
            [Required]
            public string Language { get; set; }
        }

        public class StoreRequest
        {
            [Required]
            public int StoreId { get; set; }
        }
}