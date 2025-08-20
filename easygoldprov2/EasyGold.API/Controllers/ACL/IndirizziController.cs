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
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.API.Services.Interfaces.SistemaEasyGold; // Assicurati di usare il corretto namespace per l'interfaccia del token service

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione degli indirizzi.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IndirizziController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISistemaEasyGoldTokenService _tokenService;
        private readonly string _baseUri = "http://sistemaeasygold.ddns.net/api/indirizzi"; // Assicurati che l'URL sia corretto

        public IndirizziController(HttpClient httpClient, ISistemaEasyGoldTokenService tokenService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        private async Task AddAuthenticationHeaderAsync()
        {
            // opzionale: evita NRE anche qui
            if (_tokenService is null)
                throw new InvalidOperationException("ISistemaEasyGoldTokenService non configurato.");

            var token = await _tokenService.GetTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                throw new UnauthorizedAccessException("Token non disponibile.");

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Restituisce una lista di indirizzi filtrati.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<IndirizziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIndirizziList([FromBody] IndirizziListRequest filter)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.PostAsync($"{_baseUri}/list", new StringContent(JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseListResponse<IndirizziDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }

        /// <summary>
        /// Crea o aggiorna un indirizzo.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(IndirizziDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateIndirizzo([FromBody] IndirizziDTO dto)
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
                var result = JsonSerializer.Deserialize<IndirizziDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }

        /// <summary>
        /// Restituisce un indirizzo specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IndirizziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIndirizzo(int id)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.GetAsync($"{_baseUri}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseResponse<IndirizziDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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

        /// <summary>
        /// Elimina un indirizzo specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIndirizzo(int id)
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