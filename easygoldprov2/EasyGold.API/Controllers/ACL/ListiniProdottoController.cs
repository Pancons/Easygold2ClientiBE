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
    /// Controller per la gestione dei listini prodotti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ListiniProdottoController : ControllerBase
    {
        private readonly IListiniProdottoService _listiniProdottoService;

        public ListiniProdottoController(IListiniProdottoService listiniProdottoService)
        {
            _listiniProdottoService = listiniProdottoService;
        }

        /// <summary>
        /// Restituisce una lista di listini prodotti filtrati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca listini prodotti</param>
        /// <returns>Lista listini e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ListiniProdottoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListiniProdottoList([FromBody] ListiniProdottoListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var listini = await _listiniProdottoService.GetAllAsync(filter, language);
                return Ok(listini);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un listino prodotto.
        /// </summary>
        /// <param name="dto">Dati del listino prodotto</param>
        /// <returns>Listino prodotto creato o aggiornato</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ListiniProdottoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateListiniProdotto([FromBody] ListiniProdottoDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ListiniProdottoDTO result;
                if (dto.Lis_IDAuto > 0)
                {
                    result = await _listiniProdottoService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Listino prodotto non trovato" });
                    }
                    return Ok(new BaseResponse<ListiniProdottoDTO>(result));
                }
                else
                {
                    result = await _listiniProdottoService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateListiniProdotto), new { id = result.Lis_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un listino prodotto specifico per ID.
        /// </summary>
        /// <param name="id">ID del listino prodotto</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ListiniProdottoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListiniProdotto(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _listiniProdottoService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Listino prodotto non trovato" });
                }
                return Ok(new BaseResponse<ListiniProdottoDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un listino prodotto specifico.
        /// </summary>
        /// <param name="id">ID del listino prodotto da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteListiniProdotto(int id)
        {
            try
            {
                await _listiniProdottoService.DeleteAsync(id);
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