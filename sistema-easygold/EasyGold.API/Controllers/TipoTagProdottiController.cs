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

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione dei tipi di tag prodotti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoTagProdottiController : ControllerBase
    {
        private readonly ITipoTagProdottiService _tipoTagProdottiService;

        public TipoTagProdottiController(ITipoTagProdottiService tipoTagProdottiService)
        {
            _tipoTagProdottiService = tipoTagProdottiService;
        }

        /// <summary>
        /// Restituisce una lista di tipi tag prodotti filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca tipi tag</param>
        /// <returns>Lista tipi tag e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TipoTagProdottiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoTagProdottiList([FromBody] TipoTagProdottiListRequest filter)
        {
            try
            {
                var results = await _tipoTagProdottiService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo tipo di tag prodotto o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati del tipo di tag</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoTagProdottiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTipoTagProdotto([FromBody] TipoTagProdottiDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Tpt_IDAuto > 0)
                {
                    var result = await _tipoTagProdottiService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Tipo di tag non trovato" });
                    }
                    return Ok(new BaseResponse<TipoTagProdottiDTO>(result));
                }
                else
                {
                    var newTipoTag = await _tipoTagProdottiService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateTipoTagProdotto), new { id = newTipoTag.Tpt_IDAuto }, newTipoTag);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un tipo di tag prodotto per ID.
        /// </summary>
        /// <param name="id">ID del tipo di tag</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoTagProdottiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoTagProdotto(int id)
        {
            try
            {
                var result = await _tipoTagProdottiService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Tipo di tag non trovato" });
                }
                return Ok(new BaseResponse<TipoTagProdottiDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un tipo di tag prodotto specifico.
        /// </summary>
        /// <param name="id">ID del tipo di tag da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTipoTagProdotto(int id)
        {
            try
            {
                await _tipoTagProdottiService.DeleteAsync(id);
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