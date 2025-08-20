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
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle quotazioni dei metalli.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class QuotazioneMetalliController : ControllerBase
    {
        private readonly IQuotazioneMetalliService _quotazioneMetalliService;

        public QuotazioneMetalliController(IQuotazioneMetalliService quotazioneMetalliService)
        {
            _quotazioneMetalliService = quotazioneMetalliService;
        }

        /// <summary>
        /// Restituisce una lista di quotazioni metalli filtrati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per le quotazioni metalli</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<QuotazioneMetalliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuotazioneMetalliList([FromBody] QuotazioneMetalliListRequest filter)
        {
            try
            {
                var results = await _quotazioneMetalliService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una quotazione metallo.
        /// </summary>
        /// <param name="dto">Dati della quotazione metallo</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<QuotazioneMetalliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateQuotazioneMetallo([FromBody] QuotazioneMetalliDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.mqt_IDAuto > 0)
                {
                    var result = await _quotazioneMetalliService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Quotazione metallo non trovata" });
                    }
                    return Ok(new BaseResponse<QuotazioneMetalliDTO>(result));
                }
                else
                {
                    var newQuotazione = await _quotazioneMetalliService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateQuotazioneMetallo), new { id = newQuotazione.mqt_IDAuto }, newQuotazione);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una quotazione metallo per ID.
        /// </summary>
        /// <param name="id">ID della quotazione metallo</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<QuotazioneMetalliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetQuotazioneMetallo(int id)
        {
            try
            {
                var result = await _quotazioneMetalliService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Quotazione metallo non trovata" });
                }
                return Ok(new BaseResponse<QuotazioneMetalliDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una quotazione metallo specifica.
        /// </summary>
        /// <param name="id">ID della quotazione metallo da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteQuotazioneMetallo(int id)
        {
            try
            {
                await _quotazioneMetalliService.DeleteAsync(id);
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