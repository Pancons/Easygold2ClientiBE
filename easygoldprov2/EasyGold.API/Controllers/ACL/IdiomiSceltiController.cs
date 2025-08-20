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
    /// Controller per la gestione degli idiomi scelti dai clienti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IdiomiSceltiController : ControllerBase
    {
        private readonly IIdiomiSceltiService _idiomiSceltiService;

        public IdiomiSceltiController(IIdiomiSceltiService idiomiSceltiService)
        {
            _idiomiSceltiService = idiomiSceltiService;
        }

        /// <summary>
        /// Restituisce una lista di idiomi scelti filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per gli idiomi scelti</param>
        /// <returns>Lista di idiomi scelti e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<IdiomiSceltiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdiomiSceltiList([FromBody] IdiomiSceltiListRequest filter)
        {
            try
            {
                var idiomiScelti = await _idiomiSceltiService.GetAllAsync(filter);
                return Ok(idiomiScelti);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un idioma scelto.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IdiomiSceltiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateIdiomScelto([FromBody] IdiomiSceltiDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IdiomiSceltiDTO result;
                if (dto.Idm_IDAuto > 0)
                {
                    result = await _idiomiSceltiService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Idioma scelto non trovato" });
                    }
                    return Ok(new BaseResponse<IdiomiSceltiDTO>(result));
                }
                else
                {
                    result = await _idiomiSceltiService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateIdiomScelto), new { id = result.Idm_IDAuto }, result);
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un idioma scelto specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IdiomiSceltiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdiomScelto(int id)
        {
            try
            {
                var result = await _idiomiSceltiService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Idioma scelto non trovato" });
                }
                return Ok(new BaseResponse<IdiomiSceltiDTO>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un idioma scelto specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIdiomScelto(int id)
        {
            try
            {
                await _idiomiSceltiService.DeleteAsync(id);
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