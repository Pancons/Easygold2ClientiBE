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
    /// Controller per la gestione delle imprese finanziarie.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ImpFinanziarieController : ControllerBase
    {
        private readonly IImpFinanziarieService _impFinanziarieService;

        public ImpFinanziarieController(IImpFinanziarieService impFinanziarieService)
        {
            _impFinanziarieService = impFinanziarieService;
        }

        /// <summary>
        /// Restituisce una lista di imprese finanziarie filtrate e paginate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca imprese finanziarie</param>
        /// <returns>Lista imprese finanziarie e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ImpFinanziarieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImpFinanziarieList([FromBody] ImpFinanziarieListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var impFinanziarie = await _impFinanziarieService.GetAllAsync(filter, language);
                return Ok(impFinanziarie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un'impresa finanziaria.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ImpFinanziarieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateImpFinanziaria([FromBody] ImpFinanziarieDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ImpFinanziarieDTO result;
                if (dto.Imf_IDAuto > 0)
                {
                    result = await _impFinanziarieService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Impresa finanziaria non trovata" });
                    }
                    return Ok(new BaseResponse<ImpFinanziarieDTO>(result));
                }
                else
                {
                    result = await _impFinanziarieService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateImpFinanziaria), new { id = result.Imf_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un'impresa finanziaria specifica per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ImpFinanziarieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImpFinanziaria(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _impFinanziarieService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Impresa finanziaria non trovata" });
                }
                return Ok(new BaseResponse<ImpFinanziarieDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un'impresa finanziaria specifica.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImpFinanziaria(int id)
        {
            try
            {
                await _impFinanziarieService.DeleteAsync(id);
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