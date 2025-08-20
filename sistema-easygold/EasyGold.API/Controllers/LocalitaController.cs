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

using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione delle località.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LocalitaController : ControllerBase
    {
        private readonly ILocalitaService _localitaService;

        public LocalitaController(ILocalitaService localitaService)
        {
            _localitaService = localitaService;
        }

        /// <summary>
        /// Restituisce una lista di località filtrate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca località</param>
        /// <returns>Lista località e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<LocalitaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocalitaList([FromBody] LocalitaListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var localitaList = await _localitaService.GetAllAsync(filter, language);
                return Ok(localitaList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una località.
        /// </summary>
        /// <param name="dto">Dati della località</param>
        /// <returns>Località creata o aggiornata</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<LocalitaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateLocalita([FromBody] LocalitaDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LocalitaDTO result;
                if (dto.Str_IDAuto > 0)
                {
                    result = await _localitaService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Località non trovata" });
                    }
                    return Ok(new BaseResponse<LocalitaDTO>(result));
                }
                else
                {
                    result = await _localitaService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateLocalita), new { id = result.Str_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una località specifica per ID.
        /// </summary>
        /// <param name="id">ID della località</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<LocalitaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocalita(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _localitaService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Località non trovata" });
                }
                return Ok(new BaseResponse<LocalitaDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una località specifica.
        /// </summary>
        /// <param name="id">ID della località da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLocalita(int id)
        {
            try
            {
                await _localitaService.DeleteAsync(id);
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