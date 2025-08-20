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
    /// Controller per la gestione delle traduzioni delle nazioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IdISONazioniController : ControllerBase
    {
        private readonly IIdISONazioniService _idISONazioniService;

        public IdISONazioniController(IIdISONazioniService idISONazioniService)
        {
            _idISONazioniService = idISONazioniService;
        }

        /// <summary>
        /// Restituisce una lista di traduzioni delle nazioni.
        /// </summary>
        /// <param name="filter">Filtri di ricerca traduzioni</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<IdISONazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdISONazioniList([FromBody] IdISONazioniListRequest filter)
        {
            try
            {
                var results = await _idISONazioniService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova traduzione di una nazione o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della traduzione</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IdISONazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateIdISONazione([FromBody] IdISONazioniDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Ntnid_ID > 0)
                {
                    var result = await _idISONazioniService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Traduzione non trovata" });
                    }
                    return Ok(new BaseResponse<IdISONazioniDTO>(result));
                }
                else
                {
                    var newTranslation = await _idISONazioniService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateIdISONazione), new { id = newTranslation.Ntnid_ID }, newTranslation);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una traduzione per ID.
        /// </summary>
        /// <param name="id">ID della traduzione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IdISONazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdISONazione(int id)
        {
            try
            {
                var result = await _idISONazioniService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Traduzione non trovata" });
                }
                return Ok(new BaseResponse<IdISONazioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una traduzione specifica.
        /// </summary>
        /// <param name="id">ID della traduzione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIdISONazione(int id)
        {
            try
            {
                await _idISONazioniService.DeleteAsync(id);
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