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
using EasyGold.Web2.Models.Comune.Valute;
using EasyGold.API.Services.Interfaces.SistemaEasyGold; // Assicurati di usare il corretto namespace per l'interfaccia del token service

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle Valute.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ValuteComuneController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISistemaEasyGoldTokenService _tokenService;
        private readonly string _baseUri = "http://sistemaeasygold.ddns.net/api/valuteComune"; // Assicurati che il URL base sia corretto

        public ValuteComuneController(HttpClient httpClient, ISistemaEasyGoldTokenService tokenService)
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
        /// Restituisce l'elenco delle valute per il dropdown.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ValuteComuneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetValuteList([FromBody] ValuteComuneListRequest request)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.PostAsync($"{_baseUri}/list", new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseListResponse<ValuteComuneDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, new { error = "Errore interno", ex = response.ReasonPhrase });
            }
        }

        /// <summary>
        /// Restituisce i dettagli di una Valuta specifica.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ValuteComuneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            await AddAuthenticationHeaderAsync();
            var response = await _httpClient.GetAsync($"{_baseUri}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BaseResponse<ValuteComuneDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
    }
}