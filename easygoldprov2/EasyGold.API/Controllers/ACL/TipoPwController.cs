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
    /// Controller per la gestione dei tipi di password.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPwController : ControllerBase
    {
        private readonly ITipoPwService _tipoPwService;

        public TipoPwController(ITipoPwService tipoPwService)
        {
            _tipoPwService = tipoPwService;
        }

        /// <summary>
        /// Restituisce una lista di tipi di password filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per i tipi di password</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TipoPwDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoPwList([FromBody] TipoPwListRequest filter)
        {
            try
            {
                var results = await _tipoPwService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo tipo di password o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati del tipo di password</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoPwDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTipoPw([FromBody] TipoPwDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Tpp_IDAuto > 0)
                {
                    var result = await _tipoPwService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Tipo password non trovato" });
                    }
                    return Ok(new BaseResponse<TipoPwDTO>(result));
                }
                else
                {
                    var newPw = await _tipoPwService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateTipoPw), new { id = newPw.Tpp_IDAuto }, newPw);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un tipo di password per ID.
        /// </summary>
        /// <param name="id">ID del tipo di password</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoPwDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoPw(int id)
        {
            try
            {
                var result = await _tipoPwService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Tipo password non trovato" });
                }
                return Ok(new BaseResponse<TipoPwDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un tipo di password specifico.
        /// </summary>
        /// <param name="id">ID del tipo di password da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTipoPw(int id)
        {
            try
            {
                await _tipoPwService.DeleteAsync(id);
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
