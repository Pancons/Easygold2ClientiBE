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
    /// Controller per la gestione degli indirizzi.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IndirizziController : ControllerBase
    {
        private readonly IIndirizziService _indirizziService;

        public IndirizziController(IIndirizziService indirizziService)
        {
            _indirizziService = indirizziService;
        }

        /// <summary>
        /// Restituisce una lista di indirizzi filtrati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca indirizzi</param>
        /// <returns>Lista indirizzi e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<IndirizziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIndirizziList([FromBody] IndirizziListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var indirizzi = await _indirizziService.GetAllAsync(filter, language);
                return Ok(indirizzi);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un indirizzo.
        /// </summary>
        /// <param name="dto">Dati dell'indirizzo</param>
        /// <returns>Indirizzo creato o aggiornato</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IndirizziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateIndirizzo([FromBody] IndirizziDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IndirizziDTO result;
                if (dto.Str_IDAuto > 0)
                {
                    result = await _indirizziService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Indirizzo non trovato" });
                    }
                    return Ok(new BaseResponse<IndirizziDTO>(result));
                }
                else
                {
                    result = await _indirizziService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateIndirizzo), new { id = result.Str_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un indirizzo specifico per ID.
        /// </summary>
        /// <param name="id">ID dell'indirizzo</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<IndirizziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIndirizzo(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _indirizziService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Indirizzo non trovato" });
                }
                return Ok(new BaseResponse<IndirizziDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un indirizzo specifico.
        /// </summary>
        /// <param name="id">ID dell'indirizzo da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIndirizzo(int id)
        {
            try
            {
                await _indirizziService.DeleteAsync(id);
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