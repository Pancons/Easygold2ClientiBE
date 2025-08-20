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
    /// Controller per la gestione degli Stati e Regioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatoRegioniController : ControllerBase
    {
        private readonly IStatoRegioniService _statoRegioniService;

        public StatoRegioniController(IStatoRegioniService statoRegioniService)
        {
            _statoRegioniService = statoRegioniService;
        }

        /// <summary>
        /// Restituisce una lista di Stati o Regioni filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca Stati/Regioni</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<StatoRegioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatoRegioniList([FromBody] StatoRegioniListRequest filter)
        {
            try
            {
                var results = await _statoRegioniService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova Stato/Regione o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati dello Stato/Regione</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<StatoRegioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateStatoRegione([FromBody] StatoRegioniDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Str_IDAuto > 0)
                {
                    var result = await _statoRegioniService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Stato/Regione non trovata" });
                    }
                    return Ok(new BaseResponse<StatoRegioniDTO>(result));
                }
                else
                {
                    var newStatoRegione = await _statoRegioniService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateStatoRegione), new { id = newStatoRegione.Str_IDAuto }, newStatoRegione);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce uno Stato/Regione per ID.
        /// </summary>
        /// <param name="id">ID dello Stato/Regione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<StatoRegioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatoRegione(int id)
        {
            try
            {
                var result = await _statoRegioniService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Stato/Regione non trovato" });
                }
                return Ok(new BaseResponse<StatoRegioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina uno Stato/Regione specifico.
        /// </summary>
        /// <param name="id">ID dello Stato/Regione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStatoRegione(int id)
        {
            try
            {
                await _statoRegioniService.DeleteAsync(id);
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