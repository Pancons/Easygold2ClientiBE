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
    /// Controller per la gestione dei listini a tabella.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ListiniTabellaController : ControllerBase
    {
        private readonly IListiniTabellaService _listiniTabellaService;

        public ListiniTabellaController(IListiniTabellaService listiniTabellaService)
        {
            _listiniTabellaService = listiniTabellaService;
        }

        /// <summary>
        /// Restituisce una lista di listini tabella filtrati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca listini</param>
        /// <returns>Lista listini e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ListiniTabellaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListiniTabellaList([FromBody] ListiniTabellaListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var listini = await _listiniTabellaService.GetAllAsync(filter, language);
                return Ok(listini);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un listino tabella.
        /// </summary>
        /// <param name="dto">Dati del listino tabella</param>
        /// <returns>Listino creato o aggiornato</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ListiniTabellaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateListinoTabella([FromBody] ListiniTabellaDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ListiniTabellaDTO result;
                if (dto.Lst_IDAuto > 0)
                {
                    result = await _listiniTabellaService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Listino non trovato" });
                    }
                    return Ok(new BaseResponse<ListiniTabellaDTO>(result));
                }
                else
                {
                    result = await _listiniTabellaService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateListinoTabella), new { id = result.Lst_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un listino tabella specifico per ID.
        /// </summary>
        /// <param name="id">ID del listino</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ListiniTabellaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListinoTabella(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _listiniTabellaService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Listino non trovato" });
                }
                return Ok(new BaseResponse<ListiniTabellaDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un listino tabella specifico.
        /// </summary>
        /// <param name="id">ID del listino da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteListinoTabella(int id)
        {
            try
            {
                await _listiniTabellaService.DeleteAsync(id);
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