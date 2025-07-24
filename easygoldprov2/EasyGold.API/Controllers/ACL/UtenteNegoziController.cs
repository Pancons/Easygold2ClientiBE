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
    /// Controller per la gestione degli utenti negozi.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UtenteNegoziController : ControllerBase
    {
        private readonly IUtenteNegoziService _utenteNegoziService;

        public UtenteNegoziController(IUtenteNegoziService utenteNegoziService)
        {
            _utenteNegoziService = utenteNegoziService;
        }

        /// <summary>
        /// Restituisce una lista di utenti negozi filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per gli utenti negozi</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<UtenteNegoziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUtenteNegoziList([FromBody] UtenteNegoziListRequest filter)
        {
            try
            {
                var results = await _utenteNegoziService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo utente negozio o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati dell'utente negozio</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<UtenteNegoziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateUtenteNegozio([FromBody] UtenteNegoziDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Utn_IDAuto > 0)
                {
                    var result = await _utenteNegoziService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Utente negozio non trovato" });
                    }
                    return Ok(new BaseResponse<UtenteNegoziDTO>(result));
                }
                else
                {
                    var newNegozio = await _utenteNegoziService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateUtenteNegozio), new { id = newNegozio.Utn_IDAuto }, newNegozio);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un utente negozio per ID.
        /// </summary>
        /// <param name="id">ID dell'utente negozio</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<UtenteNegoziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUtenteNegozio(int id)
        {
            try
            {
                var result = await _utenteNegoziService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Utente negozio non trovato" });
                }
                return Ok(new BaseResponse<UtenteNegoziDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un utente negozio specifico.
        /// </summary>
        /// <param name="id">ID dell'utente negozio da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUtenteNegozio(int id)
        {
            try
            {
                await _utenteNegoziService.DeleteAsync(id);
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