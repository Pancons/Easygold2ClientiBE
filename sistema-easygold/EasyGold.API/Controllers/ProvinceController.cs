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
    /// Controller per la gestione delle province.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        /// <summary>
        /// Ottiene una lista di province filtrate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca province</param>
        /// <returns>Lista province e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ProvinceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProvinceList([FromBody] ProvinceListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var provinces = await _provinceService.GetAllAsync(filter, language);
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una provincia.
        /// </summary>
        /// <param name="dto">Dati della provincia</param>
        /// <returns>Provincia creata o aggiornata</returns>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ProvinceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateProvince([FromBody] ProvinceDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ProvinceDTO result;
                if (dto.Str_IDAuto > 0)
                {
                    result = await _provinceService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Provincia non trovata" });
                    }
                    return Ok(new BaseResponse<ProvinceDTO>(result));
                }
                else
                {
                    result = await _provinceService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateProvince), new { id = result.Str_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una provincia specifica per ID.
        /// </summary>
        /// <param name="id">ID della provincia</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ProvinceDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProvince(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _provinceService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Provincia non trovata" });
                }
                return Ok(new BaseResponse<ProvinceDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una provincia specifica.
        /// </summary>
        /// <param name="id">ID della provincia da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            try
            {
                await _provinceService.DeleteAsync(id);
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