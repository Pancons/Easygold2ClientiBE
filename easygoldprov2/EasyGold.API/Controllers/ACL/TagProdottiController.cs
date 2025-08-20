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
    /// Controller per la gestione dei tag prodotti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TagProdottiController : ControllerBase
    {
        private readonly ITagProdottiService _tagProdottiService;

        public TagProdottiController(ITagProdottiService tagProdottiService)
        {
            _tagProdottiService = tagProdottiService;
        }

        /// <summary>
        /// Restituisce una lista di tag prodotti filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca tag prodotti</param>
        /// <returns>Lista tag prodotti e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TagProdottiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTagProdottiList([FromBody] TagProdottiListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var tags = await _tagProdottiService.GetAllAsync(filter, language);
                return Ok(tags);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un tag prodotto.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TagProdottiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTagProdotto([FromBody] TagProdottiDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                TagProdottiDTO result;
                if (dto.Etp_IDAuto > 0)
                {
                    result = await _tagProdottiService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Tag prodotto non trovato" });
                    }
                    return Ok(new BaseResponse<TagProdottiDTO>(result));
                }
                else
                {
                    result = await _tagProdottiService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateTagProdotto), new { id = result.Etp_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un tag prodotto specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TagProdottiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTagProdotto(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _tagProdottiService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Tag prodotto non trovato" });
                }
                return Ok(new BaseResponse<TagProdottiDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un tag prodotto specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTagProdotto(int id)
        {
            try
            {
                await _tagProdottiService.DeleteAsync(id);
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