using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei numeri Registri IVA.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NumeriRegIVAController : ControllerBase
    {
        private readonly INumeriRegIVAService _numeriRegIVAService;

        public NumeriRegIVAController(INumeriRegIVAService numeriRegIVAService)
        {
            _numeriRegIVAService = numeriRegIVAService;
        }

        /// <summary>
        /// Restituisce una lista di numeri registro IVA filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca numeri registro IVA</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<NumeriRegIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNumeriRegIVAList([FromBody] NumeriRegIVAListRequest filter)
        {
            try
            {
                var results = await _numeriRegIVAService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo numero registro IVA o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati del numero registro IVA</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NumeriRegIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateNumeriRegIVA([FromBody] NumeriRegIVADTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.RowIDAuto > 0)
                {
                    var result = await _numeriRegIVAService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Numero registro IVA non trovato" });
                    }
                    return Ok(new BaseResponse<NumeriRegIVADTO>(result));
                }
                else
                {
                    var newNumeroRegIVA = await _numeriRegIVAService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateNumeriRegIVA), new { id = newNumeroRegIVA.RowIDAuto }, newNumeroRegIVA);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un numero registro IVA per ID.
        /// </summary>
        /// <param name="id">ID del numero registro IVA</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NumeriRegIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNumeriRegIVA(int id)
        {
            try
            {
                var result = await _numeriRegIVAService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Numero registro IVA non trovato" });
                }
                return Ok(new BaseResponse<NumeriRegIVADTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un numero registro IVA specifico.
        /// </summary>
        /// <param name="id">ID del numero registro IVA da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNumeriRegIVA(int id)
        {
            try
            {
                await _numeriRegIVAService.DeleteAsync(id);
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