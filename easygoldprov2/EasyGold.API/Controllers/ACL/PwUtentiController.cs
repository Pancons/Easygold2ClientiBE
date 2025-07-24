using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle password degli utenti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PwUtentiController : ControllerBase
    {
        private readonly IPwUtentiService _pwUtentiService;

        public PwUtentiController(IPwUtentiService pwUtentiService)
        {
            _pwUtentiService = pwUtentiService;
        }

        /// <summary>
        /// Restituisce una lista di password utenti filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per le password utenti</param>
        /// <returns>Lista di password utenti e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<PwUtentiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPwUtentiList([FromBody] PwUtentiListRequest filter)
        {
            try
            {
                var passwords = await _pwUtentiService.GetAllAsync(filter);
                return Ok(passwords);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una password utente.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<PwUtentiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdatePwUtente([FromBody] PwUtentiDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                PwUtentiDTO result;
                if (dto.Utp_IDAuto > 0)
                {
                    result = await _pwUtentiService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Password non trovata" });
                    }
                    return Ok(new BaseResponse<PwUtentiDTO>(result));
                }
                else
                {
                    result = await _pwUtentiService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdatePwUtente), new { id = result.Utp_IDAuto }, result);
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una password utente specifica per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<PwUtentiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPwUtente(int id)
        {
            try
            {
                var result = await _pwUtentiService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Password non trovata" });
                }
                return Ok(new BaseResponse<PwUtentiDTO>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una password utente specifica.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePwUtente(int id)
        {
            try
            {
                await _pwUtentiService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }
    }
}