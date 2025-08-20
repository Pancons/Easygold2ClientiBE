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
    /// Controller per la gestione delle causali comuni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CausaliComuneController : ControllerBase
    {
        private readonly ICausaliComuneService _causaliComuneService;

        public CausaliComuneController(ICausaliComuneService causaliComuneService)
        {
            _causaliComuneService = causaliComuneService;
        }

        /// <summary>
        /// Restituisce una lista di causali comuni filtrate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca causali</param>
        /// <returns>Lista causali e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<CausaliComuneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCausaliComuneList([FromBody] CausaliComuneListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var causaliComuni = await _causaliComuneService.GetAllAsync(filter, language);
                return Ok(causaliComuni);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una causale comune.
        /// </summary>
        /// <param name="dto">Dati della causale</param>
        /// <returns>Causale creata o aggiornata</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CausaliComuneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateCausaleComune([FromBody] CausaliComuneDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CausaliComuneDTO result;
                if (dto.Cac_IDAuto > 0)
                {
                    result = await _causaliComuneService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Causale non trovata" });
                    }
                    return Ok(new BaseResponse<CausaliComuneDTO>(result));
                }
                else
                {
                    result = await _causaliComuneService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateCausaleComune), new { id = result.Cac_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una causale comune specifica per ID.
        /// </summary>
        /// <param name="id">ID della causale</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CausaliComuneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCausaleComune(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _causaliComuneService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Causale non trovata" });
                }
                return Ok(new BaseResponse<CausaliComuneDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una causale comune specifica.
        /// </summary>
        /// <param name="id">ID della causale da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCausaleComune(int id)
        {
            try
            {
                await _causaliComuneService.DeleteAsync(id);
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