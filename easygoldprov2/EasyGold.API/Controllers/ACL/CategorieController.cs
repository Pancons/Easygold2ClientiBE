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
using EasyGold.Web2.Models.Cliente.CategorieProdotto;
using EasyGold.Web2.Models.Cliente.Entities.CategorieProdotto;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle categorie prodotto.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        /// <summary>
        /// Restituisce una lista di categorie filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca categorie</param>
        /// <returns>Lista categorie e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<CategorieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategorieList([FromBody] CategorieListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var categories = await _categorieService.GetAllAsync(filter, language);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una categoria.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CategorieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateCategoria([FromBody] CategorieDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CategorieDTO result;
                if (dto.Cat_IDAuto > 0)
                {
                    result = await _categorieService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Categoria non trovata" });
                    }
                    return Ok(new BaseResponse<CategorieDTO>(result));
                }
                else
                {
                    result = await _categorieService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateCategoria), new { id = result.Cat_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una categoria specifica per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CategorieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategoria(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _categorieService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Categoria non trovata" });
                }
                return Ok(new BaseResponse<CategorieDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una categoria specifica.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                await _categorieService.DeleteAsync(id);
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