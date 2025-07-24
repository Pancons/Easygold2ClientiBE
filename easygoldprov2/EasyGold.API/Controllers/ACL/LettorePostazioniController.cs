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
    /// Controller per la gestione dei lettori di card per le postazioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LettorePostazioniController : ControllerBase
    {
        private readonly ILettorePostazioniService _lettorePostazioniService;

        public LettorePostazioniController(ILettorePostazioniService lettorePostazioniService)
        {
            _lettorePostazioniService = lettorePostazioniService;
        }

        /// <summary>
        /// Restituisce una lista di lettori card per le postazioni filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca per i lettori</param>
        /// <returns>Lista di lettori di card per le postazioni</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<LettorePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLettoriPostazioniList([FromBody] LettorePostazioniListRequest filter)
        {
            try
            {
                var lettori = await _lettorePostazioniService.GetAllAsync(filter);
                return Ok(lettori);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un lettore di card per una postazione.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<LettorePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateLettorePostazione([FromBody] LettorePostazioniDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LettorePostazioniDTO result;
                if (dto.Lpo_IDAuto > 0)
                {
                    result = await _lettorePostazioniService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Lettore non trovato" });
                    }
                    return Ok(new BaseResponse<LettorePostazioniDTO>(result));
                }
                else
                {
                    result = await _lettorePostazioniService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateLettorePostazione), new { id = result.Lpo_IDAuto }, result);
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un lettore di card specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<LettorePostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLettorePostazione(int id)
        {
            try
            {
                var result = await _lettorePostazioniService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Lettore non trovato" });
                }
                return Ok(new BaseResponse<LettorePostazioniDTO>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un lettore di card specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLettorePostazione(int id)
        {
            try
            {
                await _lettorePostazioniService.DeleteAsync(id);
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