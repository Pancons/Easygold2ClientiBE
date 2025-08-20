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
    /// Controller per la gestione delle causali.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CausaliController : ControllerBase
    {
        private readonly ICausaliService _causaliService;

        public CausaliController(ICausaliService causaliService)
        {
            _causaliService = causaliService;
        }

        /// <summary>
        /// Restituisce una lista di causali filtrate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca causali</param>
        /// <returns>Lista causali e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<CausaliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCausaliList([FromBody] CausaliListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var causali = await _causaliService.GetAllAsync(filter, language);
                return Ok(causali);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una causale.
        /// </summary>
        /// <param name="dto">Dati della causale</param>
        /// <returns>Causale creata o aggiornata</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CausaliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateCausale([FromBody] CausaliDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CausaliDTO result;
                if (dto.Cal_IDAuto > 0)
                {
                    result = await _causaliService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Causale non trovata" });
                    }
                    return Ok(new BaseResponse<CausaliDTO>(result));
                }
                else
                {
                    result = await _causaliService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateCausale), new { id = result.Cal_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una causale specifica per ID.
        /// </summary>
        /// <param name="id">ID della causale</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CausaliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCausale(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _causaliService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Causale non trovata" });
                }
                return Ok(new BaseResponse<CausaliDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una causale specifica.
        /// </summary>
        /// <param name="id">ID della causale da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCausale(int id)
        {
            try
            {
                await _causaliService.DeleteAsync(id);
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