using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;           
//using EasyGold.API.Models.Clienti;
using EasyGold.Web2.Models.Comune.Allegati;
using EasyGold.API.Services.Implementations.SistemaEasyGold;
using EasyGold.API.Services.Interfaces.SistemaEasyGold;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione degli allegati.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AllegatoController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISistemaEasyGoldTokenService _tokenService;
        private readonly string _baseUri = "http://sistemaeasygold.ddns.net/api/allegato"; // Assicurati che il URL base sia corretto

        public AllegatoController(HttpClient httpClient, ISistemaEasyGoldTokenService tokenService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        private async Task AddAuthenticationHeaderAsync()
        {
            var token = await _tokenService.GetTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                throw new UnauthorizedAccessException("Token non disponibile.");

            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<AllegatoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllegatoList([FromBody] AllegatoListRequest filter)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.PostAsync($"{_baseUri}/list", new StringContent(JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseListResponse<AllegatoDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore esterno", ex = response.ReasonPhrase });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<AllegatoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllegato(int id)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.GetAsync($"{_baseUri}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseResponse<AllegatoDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(AllegatoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateAllegato([FromBody] AllegatoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.PostAsync($"{_baseUri}/save", new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<AllegatoDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAllegato(int id)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.DeleteAsync($"{_baseUri}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }
    }
}
