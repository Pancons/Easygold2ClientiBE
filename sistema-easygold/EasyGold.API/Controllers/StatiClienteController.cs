using EasyGold.API.Models;
using EasyGold.API.Models.StatiCliente;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Models.Valute;
using EasyGold.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione degli Stati Cliente.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatiClienteController : ControllerBase
    {
        private readonly IStatiClienteService _statoClienteService; // 🔹 Usa il servizio invece del repository

        public StatiClienteController(IStatiClienteService statoClienteService)
        {
            _statoClienteService = statoClienteService;
        }

        /// <summary>
        /// Restituisce l'elenco degli stati cliente per il dropdown.
        /// </summary>
        /// <returns>Lista degli stati cliente</returns>
        /// <response code="200">Stati cliente con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<StatoClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatiClienteList([FromBody] StatoClienteListRequest request)
        {
            try
            {
                var results = await _statoClienteService.GetAllAsync(request);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce i dettagli di uno Stato Cliente specifico.
        /// </summary>
        /// <param name="id">ID dello Stato Cliente</param>
        /// <returns>Dettagli dello Stato Cliente</returns>
        /// <response code="200">Dettagli Stato Cliente restituiti</response>
        /// <response code="404">Stato Cliente non trovato</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<StatoClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _statoClienteService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new BaseResponse<StatoClienteDTO>(result));
        }


    }
}
