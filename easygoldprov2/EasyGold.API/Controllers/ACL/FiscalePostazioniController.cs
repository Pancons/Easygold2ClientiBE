using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle postazioni fiscali.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FiscalePostazioniController : ControllerBase
    {
        private readonly IFiscalePostazioniService _fiscalePostazioniService;

        public FiscalePostazioniController(IFiscalePostazioniService fiscalePostazioniService)
        {
            _fiscalePostazioniService = fiscalePostazioniService;
        }

        /// <summary>
        /// Restituisce una lista di postazioni fiscali filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca postazioni</param>
        /// <returns>Lista postazioni e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<FiscalePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFiscalePostazioniList([FromBody] FiscalePostazioniListRequest filter)
        {
            try
            {
                var results = await _fiscalePostazioniService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova postazione fiscale o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della postazione fiscale</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<FiscalePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateFiscalePostazione([FromBody] FiscalePostazioniDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Fpo_IDAuto > 0)
                {
                    var result = await _fiscalePostazioniService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Postazione non trovata" });
                    }
                    return Ok(new BaseResponse<FiscalePostazioniDTO>(result));
                }
                else
                {
                    var newPostazione = await _fiscalePostazioniService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateFiscalePostazione), new { id = newPostazione.Fpo_IDAuto }, newPostazione);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una postazione fiscale per ID.
        /// </summary>
        /// <param name="id">ID della postazione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<FiscalePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFiscalePostazione(int id)
        {
            try
            {
                var result = await _fiscalePostazioniService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Postazione non trovata" });
                }
                return Ok(new BaseResponse<FiscalePostazioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una postazione fiscale specifica.
        /// </summary>
        /// <param name="id">ID della postazione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFiscalePostazione(int id)
        {
            try
            {
                await _fiscalePostazioniService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }
    }
}