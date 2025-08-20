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
    /// Controller per la gestione delle configurazioni delle categorie prodotto.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigCategorieController : ControllerBase
    {
        private readonly IConfigCategorieService _configCategorieService;

        public ConfigCategorieController(IConfigCategorieService configCategorieService)
        {
            _configCategorieService = configCategorieService;
        }

        /// <summary>
        /// Restituisce una lista di configurazioni di categorie prodotto filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca configurazioni</param>
        /// <returns>Lista configurazioni e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ConfigCategorieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetConfigCategorieList([FromBody] ConfigCategorieListRequest filter)
        {
            try
            {
                var results = await _configCategorieService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova configurazione di categoria prodotto o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della configurazione di categoria</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ConfigCategorieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateConfigCategorie([FromBody] ConfigCategorieDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Coc_IDAuto > 0)
                {
                    var result = await _configCategorieService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Configurazione non trovata" });
                    }
                    return Ok(new BaseResponse<ConfigCategorieDTO>(result));
                }
                else
                {
                    var newConfig = await _configCategorieService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateConfigCategorie), new { id = newConfig.Coc_IDAuto }, newConfig);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una configurazione di categoria prodotto per ID.
        /// </summary>
        /// <param name="id">ID della configurazione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<ConfigCategorieDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetConfigCategorie(int id)
        {
            try
            {
                var result = await _configCategorieService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Configurazione non trovata" });
                }
                return Ok(new BaseResponse<ConfigCategorieDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una configurazione di categoria prodotto specifica.
        /// </summary>
        /// <param name="id">ID della configurazione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteConfigCategorie(int id)
        {
            try
            {
                await _configCategorieService.DeleteAsync(id);
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
    }
}