using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.API.Models.Moduli;

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
        /// <response code="200">Moduli restituiti con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(List<ModuloDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNationsList()
        {
            try
            {
                var results = await _nazioneService.GetAllAsync();
                if (results == null)
                {
                    return NotFound(new { message = "Nessun Nazione trovata" });
                }
                return Ok(new { results });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }



    }
}
