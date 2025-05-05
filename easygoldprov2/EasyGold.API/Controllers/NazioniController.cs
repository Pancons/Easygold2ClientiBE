using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.API.Models.Moduli;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Models.Nazioni;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione delle Nazioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NazioniController : ControllerBase
    {
        private readonly INazioneService _nazioneService; // 🔹 Usa il servizio invece del repository

        public NazioniController(INazioneService nazioneService)
        {
            _nazioneService = nazioneService;
        }

        /// <summary>
        /// Restituisce l'elenco delle nazioni per il dropdown.
        /// </summary>
        /// <returns>Lista delle nazioni</returns>
        /// <response code="200">Nazioni con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<NazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNationsList([FromBody] NazioniListRequest request)
        {
            try
            {
                var results = await _nazioneService.GetAllAsync(request);
                if (results == null || results.total == 0)
                {
                    return NotFound(new { message = "Nessun Nazione trovata" });
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce i dettagli di una Nazione specifica.
        /// </summary>
        /// <param name="id">ID della Nazione</param>
        /// <returns>Dettagli della Nazione</returns>
        /// <response code="200">Dettagli Nazione restituiti</response>
        /// <response code="404">Nazione non trovata</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(NazioniDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNazione(int id)
        {
            var result = await _nazioneService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { result });
        }


    }
}
