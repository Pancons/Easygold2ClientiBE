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
    /// Controller per la gestione dei tipi di permesso.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPermessoController : ControllerBase
    {
        private readonly ITipoPermessoService _tipoPermessoService;

        public TipoPermessoController(ITipoPermessoService tipoPermessoService)
        {
            _tipoPermessoService = tipoPermessoService;
        }

        /// <summary>
        /// Restituisce una lista di tipi di permesso filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per i tipi di permesso</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TipoPermessoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoPermessoList([FromBody] TipoPermessoListRequest filter)
        {
            try
            {
                var results = await _tipoPermessoService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo tipo di permesso o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati del tipo di permesso</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoPermessoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTipoPermesso([FromBody] TipoPermessoDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Tpa_IDAuto > 0)
                {
                    var result = await _tipoPermessoService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Tipo permesso non trovato" });
                    }
                    return Ok(new BaseResponse<TipoPermessoDTO>(result));
                }
                else
                {
                    var newPermesso = await _tipoPermessoService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateTipoPermesso), new { id = newPermesso.Tpa_IDAuto }, newPermesso);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un tipo di permesso per ID.
        /// </summary>
        /// <param name="id">ID del tipo di permesso</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoPermessoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoPermesso(int id)
        {
            try
            {
                var result = await _tipoPermessoService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Tipo permesso non trovato" });
                }
                return Ok(new BaseResponse<TipoPermessoDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un tipo di permesso specifico.
        /// </summary>
        /// <param name="id">ID del tipo di permesso da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTipoPermesso(int id)
        {
            try
            {
                await _tipoPermessoService.DeleteAsync(id);
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
