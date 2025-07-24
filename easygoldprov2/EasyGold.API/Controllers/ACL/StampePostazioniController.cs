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
    /// Controller per la gestione delle postazioni di stampa.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StampePostazioniController : ControllerBase
    {
        private readonly IStampePostazioniService _stampePostazioniService;

        public StampePostazioniController(IStampePostazioniService stampePostazioniService)
        {
            _stampePostazioniService = stampePostazioniService;
        }

        /// <summary>
        /// Restituisce una lista di postazioni di stampa filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca postazioni</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<StampePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStampePostazioniList([FromBody] StampePostazioniListRequest filter)
        {
            try
            {
                var results = await _stampePostazioniService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova postazione di stampa o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della postazione di stampa</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<StampePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateStampePostazione([FromBody] StampePostazioniDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Tpo_IDAuto > 0)
                {
                    var result = await _stampePostazioniService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Postazione non trovata" });
                    }
                    return Ok(new BaseResponse<StampePostazioniDTO>(result));
                }
                else
                {
                    var newPostazione = await _stampePostazioniService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateStampePostazione), new { id = newPostazione.Tpo_IDAuto }, newPostazione);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una postazione di stampa per ID.
        /// </summary>
        /// <param name="id">ID della postazione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<StampePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStampePostazione(int id)
        {
            try
            {
                var result = await _stampePostazioniService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Postazione non trovata" });
                }
                return Ok(new BaseResponse<StampePostazioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una postazione di stampa specifica.
        /// </summary>
        /// <param name="id">ID della postazione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStampePostazione(int id)
        {
            try
            {
                await _stampePostazioniService.DeleteAsync(id);
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
