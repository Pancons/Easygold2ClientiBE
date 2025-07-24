using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei permessi di gruppo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PermessiGruppoController : ControllerBase
    {
        private readonly IPermessiGruppoService _permessiGruppoService;

        public PermessiGruppoController(IPermessiGruppoService permessiGruppoService)
        {
            _permessiGruppoService = permessiGruppoService;
        }

        /// <summary>
        /// Restituisce una lista di permessi di gruppo filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per i permessi di gruppo</param>
        /// <returns>Lista di permessi di gruppo e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<PermessiGruppoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPermessiGruppoList([FromBody] PermessiGruppoListRequest filter)
        {
            try
            {
                var permessi = await _permessiGruppoService.GetAllAsync(filter);
                return Ok(permessi);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un permesso di gruppo.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<PermessiGruppoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdatePermessoGruppo([FromBody] PermessiGruppoDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                PermessiGruppoDTO result;
                if (dto.Abg_IDAuto > 0)
                {
                    result = await _permessiGruppoService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Permesso non trovato" });
                    }
                    return Ok(new BaseResponse<PermessiGruppoDTO>(result));
                }
                else
                {
                    result = await _permessiGruppoService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdatePermessoGruppo), new { id = result.Abg_IDAuto }, result);
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un permesso di gruppo specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<PermessiGruppoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPermessoGruppo(int id)
        {
            try
            {
                var result = await _permessiGruppoService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Permesso non trovato" });
                }
                return Ok(new BaseResponse<PermessiGruppoDTO>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un permesso di gruppo specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePermessoGruppo(int id)
        {
            try
            {
                await _permessiGruppoService.DeleteAsync(id);
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