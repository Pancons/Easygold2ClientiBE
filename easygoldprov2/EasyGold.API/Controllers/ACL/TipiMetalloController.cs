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
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei tipi di metallo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipiMetalloController : ControllerBase
    {
        private readonly ITipiMetalloService _tipiMetalloService;

        public TipiMetalloController(ITipiMetalloService tipiMetalloService)
        {
            _tipiMetalloService = tipiMetalloService;
        }

        /// <summary>
        /// Restituisce una lista di tipi di metalli filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca tipi metallo</param>
        /// <returns>Lista tipi metallo e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TipiMetalloDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipiMetalliList([FromBody] TipiMetalloListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var types = await _tipiMetalloService.GetAllAsync(filter, language);
                return Ok(types);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un tipo di metallo.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipiMetalloDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTipoMetallo([FromBody] TipiMetalloDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                TipiMetalloDTO result;
                if (dto.Tim_IDAuto > 0)
                {
                    result = await _tipiMetalloService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Tipo di metallo non trovato" });
                    }
                    return Ok(new BaseResponse<TipiMetalloDTO>(result));
                }
                else
                {
                    result = await _tipiMetalloService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateTipoMetallo), new { id = result.Tim_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un tipo di metallo specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipiMetalloDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoMetallo(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _tipiMetalloService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Tipo di metallo non trovato" });
                }
                return Ok(new BaseResponse<TipiMetalloDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un tipo di metallo specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTipoMetallo(int id)
        {
            try
            {
                await _tipiMetalloService.DeleteAsync(id);
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