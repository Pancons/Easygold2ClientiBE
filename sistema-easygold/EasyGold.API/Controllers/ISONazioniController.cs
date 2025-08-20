using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione delle ISONazioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ISONazioniController : ControllerBase
    {
        private readonly IISONazioniService _isoNazioniService;

        public ISONazioniController(IISONazioniService isoNazioniService)
        {
            _isoNazioniService = isoNazioniService;
        }

        /// <summary>
        /// Restituisce una lista di ISONazioni filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca ISONazioni</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ISONazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetISONazioniList([FromBody] ISONazioniListRequest filter)
        {
            try
            {
                var results = await _isoNazioniService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova ISONazione o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della ISONazione</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ISONazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateISONazione([FromBody] ISONazioniDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Ntn_ISO1 > 0)
                {
                    var result = await _isoNazioniService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Nazione non trovata" });
                    }
                    return Ok(new BaseResponse<ISONazioniDTO>(result));
                }
                else
                {
                    var newNazione = await _isoNazioniService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateISONazione), new { id = newNazione.Ntn_ISO1 }, newNazione);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una ISONazione per ID.
        /// </summary>
        /// <param name="id">ID della nazione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ISONazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetISONazione(int id)
        {
            try
            {
                var result = await _isoNazioniService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Nazione non trovata" });
                }
                return Ok(new BaseResponse<ISONazioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una ISONazione specifica.
        /// </summary>
        /// <param name="id">ID della nazione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteISONazione(int id)
        {
            try
            {
                await _isoNazioniService.DeleteAsync(id);
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