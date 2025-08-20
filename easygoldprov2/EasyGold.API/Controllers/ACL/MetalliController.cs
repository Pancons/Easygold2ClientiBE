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
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei metalli.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MetalliController : ControllerBase
    {
        private readonly IMetalliService _metalliService;

        public MetalliController(IMetalliService metalliService)
        {
            _metalliService = metalliService;
        }

        /// <summary>
        /// Restituisce una lista di metalli filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca metalli</param>
        /// <returns>Lista metalli e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<MetalliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMetalliList([FromBody] MetalliListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var metals = await _metalliService.GetAllAsync(filter, language);
                return Ok(metals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un metallo.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<MetalliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateMetallo([FromBody] MetalliDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MetalliDTO result;
                if (dto.met_IDAuto > 0)
                {
                    result = await _metalliService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Metallo non trovato" });
                    }
                    return Ok(new BaseResponse<MetalliDTO>(result));
                }
                else
                {
                    result = await _metalliService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateMetallo), new { id = result.met_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un metallo specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<MetalliDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMetallo(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _metalliService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Metallo non trovato" });
                }
                return Ok(new BaseResponse<MetalliDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un metallo specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMetallo(int id)
        {
            try
            {
                await _metalliService.DeleteAsync(id);
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