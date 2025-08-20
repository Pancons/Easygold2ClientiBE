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

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei tipi di SKU.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoSKUController : ControllerBase
    {
        private readonly ITipoSKUService _tipoSKUService;

        public TipoSKUController(ITipoSKUService tipoSKUService)
        {
            _tipoSKUService = tipoSKUService;
        }

        /// <summary>
        /// Restituisce una lista di tipi SKU filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca SKU</param>
        /// <returns>Lista SKU e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TipoSKUDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoSKUList([FromBody] TipoSKUListRequest filter)
        {
            try
            {
                var results = await _tipoSKUService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo tipo SKU o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati del tipo SKU</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoSKUDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTipoSKU([FromBody] TipoSKUDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Sku_IDAuto > 0)
                {
                    var result = await _tipoSKUService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Tipo SKU non trovato" });
                    }
                    return Ok(new BaseResponse<TipoSKUDTO>(result));
                }
                else
                {
                    var newSKU = await _tipoSKUService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateTipoSKU), new { id = newSKU.Sku_IDAuto }, newSKU);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un tipo SKU per ID.
        /// </summary>
        /// <param name="id">ID del tipo SKU</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoSKUDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoSKU(int id)
        {
            try
            {
                var result = await _tipoSKUService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Tipo SKU non trovato" });
                }
                return Ok(new BaseResponse<TipoSKUDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un tipo SKU specifico.
        /// </summary>
        /// <param name="id">ID del tipo SKU da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTipoSKU(int id)
        {
            try
            {
                await _tipoSKUService.DeleteAsync(id);
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