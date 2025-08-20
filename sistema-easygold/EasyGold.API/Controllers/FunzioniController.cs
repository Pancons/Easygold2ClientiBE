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
    /// Controller per la gestione delle funzioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FunzioniController : ControllerBase
    {
        private readonly IFunzioniService _funzioniService;

        public FunzioniController(IFunzioniService funzioniService)
        {
            _funzioniService = funzioniService;
        }

        /// <summary>
        /// Restituisce una lista di funzioni filtrate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca funzioni</param>
        /// <returns>Lista funzioni e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<FunzioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFunzioniList([FromBody] FunzioniListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var functions = await _funzioniService.GetAllAsync(filter, language);
                return Ok(functions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una funzione.
        /// </summary>
        /// <param name="dto">Dati della funzione</param>
        /// <returns>Funzione creata o aggiornata</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<FunzioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateFunzione([FromBody] FunzioniDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                FunzioniDTO result;
                if (dto.Abl_IDAuto > 0)
                {
                    result = await _funzioniService.UpdateAsync(dto,language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Funzione non trovata" });
                    }
                    return Ok(new BaseResponse<FunzioniDTO>(result));
                }
                else
                {
                    result = await _funzioniService.AddAsync(dto,language);
                    return CreatedAtAction(nameof(AddOrUpdateFunzione), new { id = result.Abl_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una funzione specifica per ID.
        /// </summary>
        /// <param name="id">ID della funzione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<FunzioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFunzione(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _funzioniService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Funzione non trovata" });
                }
                return Ok(new BaseResponse<FunzioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una funzione specifica.
        /// </summary>
        /// <param name="id">ID della funzione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFunzione(int id)
        {
            try
            {
                await _funzioniService.DeleteAsync(id);
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