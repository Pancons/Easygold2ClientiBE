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
    /// Controller per la gestione degli Stati e Regioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatoRegioniController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISistemaEasyGoldTokenService _tokenService;
        private readonly string _baseUri = "http://sistemaeasygold.ddns.net/api/statoRegioni"; // Assicurati che il URL base sia corretto

        public StatoRegioniController(HttpClient httpClient, ISistemaEasyGoldTokenService tokenService)
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
        /// Restituisce una lista di Stati o Regioni filtrati e paginati.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<StatoRegioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatoRegioniList([FromBody] StatoRegioniListRequest filter)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.PostAsync($"{_baseUri}/list", new StringContent(JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseListResponse<StatoRegioniDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }

        /// <summary>
        /// Crea una nuova Stato/Regione o aggiorna una esistente.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<StatoRegioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateStatoRegione([FromBody] StatoRegioniDTO dto)
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
                var result = JsonSerializer.Deserialize<StatoRegioniDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }

        /// <summary>
        /// Restituisce uno Stato/Regione per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<StatoRegioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatoRegione(int id)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.GetAsync($"{_baseUri}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseResponse<StatoRegioniDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
        /// Elimina uno Stato/Regione specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStatoRegione(int id)
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