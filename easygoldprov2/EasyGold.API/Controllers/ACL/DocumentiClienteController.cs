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
    /// Controller per la gestione dei documenti cliente.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentiClienteController : ControllerBase
    {
        private readonly IDocumentiClienteService _documentiClienteService;

        public DocumentiClienteController(IDocumentiClienteService documentiClienteService)
        {
            _documentiClienteService = documentiClienteService;
        }

        /// <summary>
        /// Restituisce una lista di documenti cliente filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca documenti cliente</param>
        /// <returns>Lista documenti cliente e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<DocumentiClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentiClienteList([FromBody] DocumentiClienteListRequest filter)
        {
            try
            {
                var results = await _documentiClienteService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo documento cliente o aggiorna uno esistente.
        /// </summary>
        /// <param name="dto">Dati del documento cliente</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<DocumentiClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateDocumentiCliente([FromBody] DocumentiClienteDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                DocumentiClienteDTO result;
                if (dto.Doc_IDAuto > 0)
                {
                    result = await _documentiClienteService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Documento cliente non trovato" });
                    }
                    return Ok(new BaseResponse<DocumentiClienteDTO>(result));
                }
                else
                {
                    var newDocumento = await _documentiClienteService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateDocumentiCliente), new { id = newDocumento.Doc_IDAuto }, newDocumento);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un documento cliente specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<DocumentiClienteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentiCliente(int id)
        {
            try
            {
                var result = await _documentiClienteService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Documento cliente non trovato" });
                }
                return Ok(new BaseResponse<DocumentiClienteDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un documento cliente specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDocumentiCliente(int id)
        {
            try
            {
                await _documentiClienteService.DeleteAsync(id);
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