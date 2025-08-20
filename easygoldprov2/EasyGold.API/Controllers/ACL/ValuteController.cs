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

using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle valute.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ValuteController : ControllerBase
    {
        private readonly IValuteService _valuteService;

        public ValuteController(IValuteService valuteService)
        {
            _valuteService = valuteService;
        }

        /// <summary>
        /// Restituisce una lista di valute filtrate.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ValuteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetValuteList([FromBody] ValuteListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var valute = await _valuteService.GetAllAsync(filter, language);
                return Ok(valute);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una valuta.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ValuteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateValuta([FromBody] ValuteDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ValuteDTO result;
                if (dto.Val_IDAuto > 0)
                {
                    result = await _valuteService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Valuta non trovata" });
                    }
                    return Ok(new BaseResponse<ValuteDTO>(result));
                }
                else
                {
                    result = await _valuteService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateValuta), new { id = result.Val_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una valuta specifica per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ValuteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetValuta(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _valuteService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Valuta non trovata" });
                }
                return Ok(new BaseResponse<ValuteDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una valuta specifica.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteValuta(int id)
        {
            try
            {
                await _valuteService.DeleteAsync(id);
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
        /// Estrae la lingua dal token.
        /// </summary>
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