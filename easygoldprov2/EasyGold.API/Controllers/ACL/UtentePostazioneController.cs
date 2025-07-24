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
    /// Controller per la gestione delle postazioni degli utenti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UtentePostazioneController : ControllerBase
    {
        private readonly IUtentePostazioneService _utentePostazioneService;

        public UtentePostazioneController(IUtentePostazioneService utentePostazioneService)
        {
            _utentePostazioneService = utentePostazioneService;
        }

        /// <summary>
        /// Restituisce una lista di postazioni utente filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per le postazioni utente</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<UtentePostazioneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUtentePostazioneList([FromBody] UtentePostazioneListRequest filter)
        {
            try
            {
                var results = await _utentePostazioneService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova postazione utente o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della postazione utente</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<UtentePostazioneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateUtentePostazione([FromBody] UtentePostazioneDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Upo_IDAuto > 0)
                {
                    var result = await _utentePostazioneService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Postazione utente non trovata" });
                    }
                    return Ok(new BaseResponse<UtentePostazioneDTO>(result));
                }
                else
                {
                    var newPostazione = await _utentePostazioneService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateUtentePostazione), new { id = newPostazione.Upo_IDAuto }, newPostazione);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una postazione utente per ID.
        /// </summary>
        /// <param name="id">ID della postazione utente</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<UtentePostazioneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUtentePostazione(int id)
        {
            try
            {
                var result = await _utentePostazioneService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Postazione utente non trovata" });
                }
                return Ok(new BaseResponse<UtentePostazioneDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una postazione utente specifica.
        /// </summary>
        /// <param name="id">ID della postazione utente da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUtentePostazione(int id)
        {
            try
            {
                await _utentePostazioneService.DeleteAsync(id);
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
