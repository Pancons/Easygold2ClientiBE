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
    /// Controller per la gestione delle aliquote IVA.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AliQuoteIVAController : ControllerBase
    {
        private readonly IAliQuoteIVAService _aliQuoteIVAService;

        public AliQuoteIVAController(IAliQuoteIVAService aliQuoteIVAService)
        {
            _aliQuoteIVAService = aliQuoteIVAService;
        }

        /// <summary>
        /// Restituisce una lista di aliquote IVA filtrate.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<AliQuoteIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAliQuoteIVAList([FromBody] AliQuoteIVAListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var aliquote = await _aliQuoteIVAService.GetAllAsync(filter, language);
                return Ok(aliquote);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un'aliquota IVA.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<AliQuoteIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateAliQuoteIVA([FromBody] AliQuoteIVADTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                AliQuoteIVADTO result;
                if (dto.Iva_IDAuto > 0)
                {
                    result = await _aliQuoteIVAService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Aliquota IVA non trovata" });
                    }
                    return Ok(new BaseResponse<AliQuoteIVADTO>(result));
                }
                else
                {
                    result = await _aliQuoteIVAService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateAliQuoteIVA), new { id = result.Iva_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un'aliquota IVA specifica per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<AliQuoteIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAliQuoteIVA(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _aliQuoteIVAService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Aliquota IVA non trovata" });
                }
                return Ok(new BaseResponse<AliQuoteIVADTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un'aliquota IVA specifica.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAliQuoteIVA(int id)
        {
            try
            {
                await _aliQuoteIVAService.DeleteAsync(id);
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