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
    /// Controller per la gestione dei registratori fiscali.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RegFiscaleController : ControllerBase
    {
        private readonly IRegFiscaleService _regFiscaleService;

        public RegFiscaleController(IRegFiscaleService regFiscaleService)
        {
            _regFiscaleService = regFiscaleService;
        }

        /// <summary>
        /// Restituisce una lista di registratori fiscali filtrati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca registratori fiscali</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<RegFiscaleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRegFiscaleList([FromBody] RegFiscaleListRequest filter)
        {
            try
            {
                var results = await _regFiscaleService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un registratore fiscale.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<RegFiscaleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateRegFiscale([FromBody] RegFiscaleDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                RegFiscaleDTO result;
                if (dto.Rfi_IDAuto > 0)
                {
                    result = await _regFiscaleService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Registratore fiscale non trovato" });
                    }
                    return Ok(new BaseResponse<RegFiscaleDTO>(result));
                }
                else
                {
                    result = await _regFiscaleService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateRegFiscale), new { id = result.Rfi_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un registratore fiscale specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<RegFiscaleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRegFiscale(int id)
        {
            try
            {
                var result = await _regFiscaleService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Registratore fiscale non trovato" });
                }
                return Ok(new BaseResponse<RegFiscaleDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un registratore fiscale specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRegFiscale(int id)
        {
            try
            {
                await _regFiscaleService.DeleteAsync(id);
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