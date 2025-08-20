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
    /// Controller per la gestione degli oneri e rivalutazioni di magazzino.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OneriRivalutazioniController : ControllerBase
    {
        private readonly IOneriRivalutazioniService _oneriRivalutazioniService;

        public OneriRivalutazioniController(IOneriRivalutazioniService oneriRivalutazioniService)
        {
            _oneriRivalutazioniService = oneriRivalutazioniService;
        }

        /// <summary>
        /// Restituisce una lista di oneri/rivalutazioni filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca oneri/rivalutazioni</param>
        /// <returns>Lista oneri/rivalutazioni e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<OneriRivalutazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOneriRivalutazioniList([FromBody] OneriRivalutazioniListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var oneriRivalutazioni = await _oneriRivalutazioniService.GetAllAsync(filter, language);
                return Ok(oneriRivalutazioni);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un onere/rivalutazione.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<OneriRivalutazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateOneriRivalutazione([FromBody] OneriRivalutazioniDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                OneriRivalutazioniDTO result;
                if (dto.Onr_IDAuto > 0)
                {
                    result = await _oneriRivalutazioniService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Onere/rivalutazione non trovato" });
                    }
                    return Ok(new BaseResponse<OneriRivalutazioniDTO>(result));
                }
                else
                {
                    result = await _oneriRivalutazioniService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateOneriRivalutazione), new { id = result.Onr_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un onere/rivalutazione specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<OneriRivalutazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOneriRivalutazione(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _oneriRivalutazioniService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Onere/rivalutazione non trovato" });
                }
                return Ok(new BaseResponse<OneriRivalutazioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un onere/rivalutazione specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOneriRivalutazione(int id)
        {
            try
            {
                await _oneriRivalutazioniService.DeleteAsync(id);
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