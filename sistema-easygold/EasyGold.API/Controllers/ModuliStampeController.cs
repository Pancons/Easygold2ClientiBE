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
    /// Controller per la gestione dei moduli di stampa.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ModuliStampeController : ControllerBase
    {
        private readonly IModuliStampeService _moduliStampeService;

        public ModuliStampeController(IModuliStampeService moduliStampeService)
        {
            _moduliStampeService = moduliStampeService;
        }

        /// <summary>
        /// Restituisce una lista di moduli di stampa filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per i moduli di stampa</param>
        /// <returns>Lista di moduli di stampa e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ModuliStampeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModuliStampeList([FromBody] ModuliStampeListRequest filter)
        {
            try
            {
                var moduli = await _moduliStampeService.GetAllAsync(filter);
                return Ok(moduli);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un modulo di stampa.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ModuliStampeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateModuloStampa([FromBody] ModuliStampeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ModuliStampeDTO result;
                if (dto.Mst_IDAuto > 0)
                {
                    result = await _moduliStampeService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Modulo non trovato" });
                    }
                    return Ok(new BaseResponse<ModuliStampeDTO>(result));
                }
                else
                {
                    result = await _moduliStampeService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateModuloStampa), new { id = result.Mst_IDAuto }, result);
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un modulo di stampa specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ModuliStampeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModuloStampa(int id)
        {
            try
            {
                var result = await _moduliStampeService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Modulo non trovato" });
                }
                return Ok(new BaseResponse<ModuliStampeDTO>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un modulo di stampa specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteModuloStampa(int id)
        {
            try
            {
                await _moduliStampeService.DeleteAsync(id);
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