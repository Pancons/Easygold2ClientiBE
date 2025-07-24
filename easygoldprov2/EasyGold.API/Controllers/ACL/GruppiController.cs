using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei gruppi.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GruppiController : ControllerBase
    {
        private readonly IGruppiService _gruppiService;

        public GruppiController(IGruppiService gruppiService)
        {
            _gruppiService = gruppiService;
        }

        /// <summary>
        /// Restituisce una lista di gruppi filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca gruppi</param>
        /// <returns>Lista gruppi e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<GruppiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGruppiList([FromBody] GruppiListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var groups = await _gruppiService.GetAllAsync(filter, language);
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un gruppo.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<GruppiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateGruppo([FromBody] GruppiDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                GruppiDTO result;
                if (dto.Grp_IDAuto > 0)
                {
                    result = await _gruppiService.UpdateAsync(dto,language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Gruppo non trovato" });
                    }
                    return Ok(new BaseResponse<GruppiDTO>(result));
                }
                else
                {
                    result = await _gruppiService.AddAsync(dto,language);
                    return CreatedAtAction(nameof(AddOrUpdateGruppo), new { id = result.Grp_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un gruppo specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<GruppiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGruppo(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _gruppiService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Gruppo non trovato" });
                }
                return Ok(new BaseResponse<GruppiDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un gruppo specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGruppo(int id)
        {
            try
            {
                await _gruppiService.DeleteAsync(id);
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
            string language = "en"; // default language

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