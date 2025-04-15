using EasyGold.API.Models;
using EasyGold.API.Models.Valute;
using EasyGold.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione delle Valute.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ValuteController : ControllerBase
    {
        private readonly IValutaService _valutaService; // 🔹 Usa il servizio invece del repository

        public ValuteController(IValutaService valutaService)
        {
            _valutaService = valutaService;
        }

        /// <summary>
        /// Restituisce l'elenco delle valute per il dropdown.
        /// </summary>
        /// <returns>Lista delle valute</returns>
        /// <response code="200">Valute con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ValuteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetValuteList([FromBody] ValuteListRequest request)
        {
            try
            {
                var results = await _valutaService.GetAllAsync(request);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce i dettagli di una Valuta specifica.
        /// </summary>
        /// <param name="id">ID della Valuta</param>
        /// <returns>Dettagli della Valuta</returns>
        /// <response code="200">Dettagli Valuta restituiti</response>
        /// <response code="404">Valuta non trovata</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ValuteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _valutaService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { result });
        }


    }
}
