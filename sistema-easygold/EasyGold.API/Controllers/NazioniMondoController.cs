using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione delle nazioni mondo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NazioniMondoController : ControllerBase
    {
        private readonly INazioniMondoService _nazioniMondoService;

        public NazioniMondoController(INazioniMondoService nazioniMondoService)
        {
            _nazioniMondoService = nazioniMondoService;
        }

        /// <summary>
        /// Restituisce una lista di nazioni filtrate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca nazione mondo</param>
        /// <returns>Lista nazioni e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<NazioniMondoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNazioniMondoList([FromBody] NazioniMondoListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var nations = await _nazioniMondoService.GetAllAsync(filter, language);
                return Ok(nations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una nazione.
        /// </summary>
        /// <param name="dto">Dati della nazione</param>
        /// <returns>Nazione creata o aggiornata</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NazioniMondoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateNazione([FromBody] NazioniMondoDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                NazioniMondoDTO result;
                if (dto.Nzm_IDAuto > 0)
                {
                    result = await _nazioniMondoService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Nazione non trovata" });
                    }
                    return Ok(new BaseResponse<NazioniMondoDTO>(result));
                }
                else
                {
                    result = await _nazioniMondoService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateNazione), new { id = result.Nzm_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una nazione specifica per ID.
        /// </summary>
        /// <param name="id">ID della nazione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NazioniMondoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNazione(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _nazioniMondoService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Nazione non trovata" });
                }
                return Ok(new BaseResponse<NazioniMondoDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una nazione specifica.
        /// </summary>
        /// <param name="id">ID della nazione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNazione(int id)
        {
            try
            {
                await _nazioniMondoService.DeleteAsync(id);
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

        /// <summary>
        /// Estrae la lingua dal token di refresh.
        /// </summary>
        /// <returns>Codice della lingua</returns>
        private string ExtractLanguageFromToken()
        {
            string refreshToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            string language = "en"; // lingua di default

            if (!string.IsNullOrEmpty(refreshToken))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(refreshToken) as JwtSecurityToken;

                language = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "language")?.Value ?? "en";
            }

            return language;
        }
    }
}