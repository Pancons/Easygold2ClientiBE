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
    /// Controller per la gestione dei documenti di funzione.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentiFunzioneController : ControllerBase
    {
        private readonly IDocumentiFunzioneService _documentiFunzioneService;

        public DocumentiFunzioneController(IDocumentiFunzioneService documentiFunzioneService)
        {
            _documentiFunzioneService = documentiFunzioneService;
        }

        /// <summary>
        /// Restituisce una lista di documenti di funzione filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca documenti</param>
        /// <returns>Lista documenti e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<DocumentiFunzioneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentiFunzioneList([FromBody] DocumentiFunzioneListRequest filter)
        {
            try
            {
                var results = await _documentiFunzioneService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un documento di funzione per ID.
        /// </summary>
        /// <param name="id">ID del documento</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<DocumentiFunzioneDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentoFunzione(int id)
        {
            try
            {
                var result = await _documentiFunzioneService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Documento non trovato" });
                }
                return Ok(new BaseResponse<DocumentiFunzioneDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un documento di funzione specifico.
        /// </summary>
        /// <param name="id">ID del documento da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDocumentoFunzione(int id)
        {
            try
            {
                await _documentiFunzioneService.DeleteAsync(id);
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