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
    /// Controller per la gestione delle informazioni fiscali delle nazioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NazioneFiscoController : ControllerBase
    {
        private readonly INazioneFiscoService _nazioneFiscoService;

        public NazioneFiscoController(INazioneFiscoService nazioneFiscoService)
        {
            _nazioneFiscoService = nazioneFiscoService;
        }

        /// <summary>
        /// Restituisce una lista di configurazioni fiscali delle nazioni filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca configurazioni fiscali</param>
        /// <returns>Lista configurazioni fiscali e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<NazioneFiscoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNazioneFiscoList([FromBody] NazioneFiscoListRequest filter)
        {
            try
            {
                var results = await _nazioneFiscoService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova configurazione fiscale della nazione o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della configurazione fiscale</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NazioneFiscoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateNazioneFisco([FromBody] NazioneFiscoDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Nfs_IDAuto > 0)
                {
                    var result = await _nazioneFiscoService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Configurazione fiscale non trovata" });
                    }
                    return Ok(new BaseResponse<NazioneFiscoDTO>(result));
                }
                else
                {
                    var newConfig = await _nazioneFiscoService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateNazioneFisco), new { id = newConfig.Nfs_IDAuto }, newConfig);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una configurazione fiscale per ID.
        /// </summary>
        /// <param name="id">ID della configurazione fiscale</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NazioneFiscoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNazioneFisco(int id)
        {
            try
            {
                var result = await _nazioneFiscoService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Configurazione fiscale non trovata" });
                }
                return Ok(new BaseResponse<NazioneFiscoDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una configurazione fiscale specifica.
        /// </summary>
        /// <param name="id">ID della configurazione fiscale da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNazioneFisco(int id)
        {
            try
            {
                await _nazioneFiscoService.DeleteAsync(id);
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