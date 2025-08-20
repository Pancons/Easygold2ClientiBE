using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.API.Services.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.Anagrafiche
{
    /// <summary>
    /// Controller per la gestione delle informazioni della Nazione del Negozio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NazioneNegozioController : ControllerBase
    {
        private readonly INazioneNegozioService _nazioneNegozioService;

        public NazioneNegozioController(INazioneNegozioService nazioneNegozioService)
        {
            _nazioneNegozioService = nazioneNegozioService;
        }

        /// <summary>
        /// Restituisce una lista di nazioni negozio filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca nazioni negozio</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<NazioneNegozioDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNazioneNegozioList([FromBody] NazioneNegozioListRequest filter)
        {
            try
            {
                var results = await _nazioneNegozioService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova nazione negozio o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della nazione negozio</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NazioneNegozioDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateNazioneNegozio([FromBody] NazioneNegozioDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Nne_IDAuto > 0)
                {
                    var result = await _nazioneNegozioService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Nazione Negozio non trovata" });
                    }
                    return Ok(new BaseResponse<NazioneNegozioDTO>(result));
                }
                else
                {
                    var newNazioneNegozio = await _nazioneNegozioService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateNazioneNegozio), new { id = newNazioneNegozio.Nne_IDAuto }, newNazioneNegozio);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una nazione negozio per ID.
        /// </summary>
        /// <param name="id">ID della nazione negozio</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NazioneNegozioDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNazioneNegozio(int id)
        {
            try
            {
                var result = await _nazioneNegozioService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Nazione Negozio non trovata" });
                }
                return Ok(new BaseResponse<NazioneNegozioDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una nazione negozio specifica.
        /// </summary>
        /// <param name="id">ID della nazione negozio da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNazioneNegozio(int id)
        {
            try
            {
                await _nazioneNegozioService.DeleteAsync(id);
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