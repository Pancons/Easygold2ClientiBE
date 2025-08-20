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
    /// Controller per la gestione dell'ordinamento delle causali.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CauOrdinamentoController : ControllerBase
    {
        private readonly ICauOrdinamentoService _cauOrdinamentoService;

        public CauOrdinamentoController(ICauOrdinamentoService cauOrdinamentoService)
        {
            _cauOrdinamentoService = cauOrdinamentoService;
        }

        /// <summary>
        /// Restituisce una lista di ordinamenti filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca ordinamenti</param>
        /// <returns>Lista ordinamenti e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<CauOrdinamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCauOrdinamentiList([FromBody] CauOrdinamentoListRequest filter)
        {
            try
            {
                var results = await _cauOrdinamentoService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo ordinamento o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati dell'ordinamento</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CauOrdinamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateCauOrdinamento([FromBody] CauOrdinamentoDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Cao_IDAuto > 0)
                {
                    var result = await _cauOrdinamentoService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Ordinamento non trovato" });
                    }
                    return Ok(new BaseResponse<CauOrdinamentoDTO>(result));
                }
                else
                {
                    var newCauOrdinamento = await _cauOrdinamentoService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateCauOrdinamento), new { id = newCauOrdinamento.Cao_IDAuto }, newCauOrdinamento);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un ordinamento per ID.
        /// </summary>
        /// <param name="id">ID dell'ordinamento</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CauOrdinamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCauOrdinamento(int id)
        {
            try
            {
                var result = await _cauOrdinamentoService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Ordinamento non trovato" });
                }
                return Ok(new BaseResponse<CauOrdinamentoDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }
        
        /// <summary>
        /// Elimina un ordinamento specifico.
        /// </summary>
        /// <param name="id">ID dell'ordinamento da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCauOrdinamento(int id)
        {
            try
            {
                await _cauOrdinamentoService.DeleteAsync(id);
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