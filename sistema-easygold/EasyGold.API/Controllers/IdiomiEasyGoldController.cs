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
    /// Controller per la gestione degli idiomi EasyGold.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IdiomiEasyGoldController : ControllerBase
    {
        private readonly IIdiomiEasyGoldService _idiomiEasyGoldService;

        public IdiomiEasyGoldController(IIdiomiEasyGoldService idiomiEasyGoldService)
        {
            _idiomiEasyGoldService = idiomiEasyGoldService;
        }

        /// <summary>
        /// Restituisce una lista di idiomi filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca idiomi</param>
        /// <returns>Lista idiomi e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<IdiomiEasyGoldDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdiomiList([FromBody] IdiomiEasyGoldListRequest filter)
        {
            try
            {
                var results = await _idiomiEasyGoldService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo idioma o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati dell'idioma</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IdiomiEasyGoldDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateIdioma([FromBody] IdiomiEasyGoldDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Idm_IDAuto > 0)
                {
                    var result = await _idiomiEasyGoldService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Idioma non trovato" });
                    }
                    return Ok(new BaseResponse<IdiomiEasyGoldDTO>(result));
                }
                else
                {
                    var newIdioma = await _idiomiEasyGoldService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateIdioma), new { id = newIdioma.Idm_IDAuto }, newIdioma);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un idioma per ID.
        /// </summary>
        /// <param name="id">ID dell'idioma</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IdiomiEasyGoldDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdioma(int id)
        {
            try
            {
                var result = await _idiomiEasyGoldService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Idioma non trovato" });
                }
                return Ok(new BaseResponse<IdiomiEasyGoldDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un idioma specifico.
        /// </summary>
        /// <param name="id">ID dell'idioma da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIdioma(int id)
        {
            try
            {
                await _idiomiEasyGoldService.DeleteAsync(id);
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