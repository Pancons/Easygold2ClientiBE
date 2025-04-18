
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Services;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Models;
using EasyGold.API.Models.Variabili;


namespace EasyGold.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ValoriTabelleController : ControllerBase
    {
        private readonly IValoriTabelleService _service;

        public ValoriTabelleController(IValoriTabelleService service)
        {
            _service = service;
        }
        /// <summary>
        /// Restituisce una lista di variabili 
        /// </summary>
        /// <param name="request">Filtro per tipologia di varabile</param>
        /// <returns>Lista variabili e totale</returns>
        /// <response code="200">Lista variabili restituita</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ValoriTabelleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> list([FromBody] VariabiliRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.LstItemType))
                return BadRequest("Il parametro lst_itemType è obbligatorio.");

            var result = await _service.FindAsync(request.LstItemType);
            return Ok(result);
        }

        /// <summary>
        /// Salva una nuova variabile o aggiorna una variabile esistente con i dettagli forniti.
        /// </summary>
        /// <param name="ValoriTabelleDTO">Dati della variabile da salvare o aggiornare</param>
        /// <returns>Variabile creato o aggiornato</returns>
        /// <response code="200">Variabile salvato o aggiornato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="404">Variabile non trovato (solo in caso di aggiornamento)</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(ValoriTabelleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] ValoriTabelleDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.SaveAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Elimina un valore tabella dato il suo ID.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

    }
}