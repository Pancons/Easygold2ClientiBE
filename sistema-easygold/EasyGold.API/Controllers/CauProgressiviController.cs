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
    /// Controller per la gestione dei progressivi delle causali.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CauProgressiviController : ControllerBase
    {
        private readonly ICauProgressiviService _cauProgressiviService;

        public CauProgressiviController(ICauProgressiviService cauProgressiviService)
        {
            _cauProgressiviService = cauProgressiviService;
        }

        /// <summary>
        /// Restituisce una lista di progressivi filtrati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca progressivi</param>
        /// <returns>Lista progressivi e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<CauProgressiviDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCauProgressiviList([FromBody] CauProgressiviListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var progressivi = await _cauProgressiviService.GetAllAsync(filter, language);
                return Ok(progressivi);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un progressivo.
        /// </summary>
        /// <param name="dto">Dati del progressivo</param>
        /// <returns>Progressivo creato o aggiornato</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CauProgressiviDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateCauProgressivo([FromBody] CauProgressiviDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CauProgressiviDTO result;
                if (dto.Cpr_IDAuto > 0)
                {
                    result = await _cauProgressiviService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Progressivo non trovato" });
                    }
                    return Ok(new BaseResponse<CauProgressiviDTO>(result));
                }
                else
                {
                    result = await _cauProgressiviService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateCauProgressivo), new { id = result.Cpr_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un progressivo specifico per ID.
        /// </summary>
        /// <param name="id">ID del progressivo</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CauProgressiviDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCauProgressivo(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _cauProgressiviService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Progressivo non trovato" });
                }
                return Ok(new BaseResponse<CauProgressiviDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un progressivo specifico.
        /// </summary>
        /// <param name="id">ID del progressivo da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCauProgressivo(int id)
        {
            try
            {
                await _cauProgressiviService.DeleteAsync(id);
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