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
    /// Controller per la gestione dei registri IVA.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RegIVAController : ControllerBase
    {
        private readonly IRegIVAService _regIVAService;

        public RegIVAController(IRegIVAService regIVAService)
        {
            _regIVAService = regIVAService;
        }

        /// <summary>
        /// Restituisce una lista di registri IVA filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca registri IVA</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<RegIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRegIVAList([FromBody] RegIVAListRequest filter)
        {
            try
            {
                var results = await _regIVAService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo registro IVA o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati del registro IVA</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<RegIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateRegIVA([FromBody] RegIVADTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.RowIdAuto > 0)
                {
                    var result = await _regIVAService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Registro IVA non trovato" });
                    }
                    return Ok(new BaseResponse<RegIVADTO>(result));
                }
                else
                {
                    var newRegIVA = await _regIVAService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateRegIVA), new { id = newRegIVA.RowIdAuto }, newRegIVA);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un registro IVA per ID.
        /// </summary>
        /// <param name="id">ID del registro IVA</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<RegIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRegIVA(int id)
        {
            try
            {
                var result = await _regIVAService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Registro IVA non trovato" });
                }
                return Ok(new BaseResponse<RegIVADTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un registro IVA specifico.
        /// </summary>
        /// <param name="id">ID del registro IVA da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRegIVA(int id)
        {
            try
            {
                await _regIVAService.DeleteAsync(id);
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