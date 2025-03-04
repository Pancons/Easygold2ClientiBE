using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Allegati;
using EasyGold.API.Services;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione degli allegati.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AllegatoController : ControllerBase
    {
        private readonly IAllegatoService _allegatoService;

        public AllegatoController(IAllegatoService allegatoService)
        {
            _allegatoService = allegatoService;
        }


        /// <summary>
        /// Restituisce tutti gli allegati disponibili.
        /// </summary>
        /// <returns>Lista degli allegati</returns>
        /// <response code="200">Lista allegati restituita con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAttachments()
        {
            var attachments = await _allegatoService.GetAllAsync();
            return Ok(new { attachments });
        }


        /// <summary>
        /// Restituisce un allegato specifico tramite ID.
        /// </summary>
        /// <param name="id">ID dell'allegato</param>
        /// <returns>Dettagli dell'allegato</returns>
        /// <response code="200">Allegato trovato</response>
        /// <response code="404">Allegato non trovato</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAttachment(int id)
        {
            var attachment = await _allegatoService.GetByIdAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }
            return Ok(new { attachment });
        }


        /// <summary>
        /// Aggiunge un nuovo allegato.
        /// </summary>
        /// <param name="attachmentDto">Dati dell'allegato da creare</param>
        /// <returns>Allegato creato</returns>
        /// <response code="201">Allegato creato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAttachment([FromBody] AllegatoDTO attachmentDto)
        {
            await _allegatoService.AddAsync(attachmentDto);
            return CreatedAtAction(nameof(GetAttachment), new { id = attachmentDto.All_IDAllegato }, attachmentDto);
        }



        /// <summary>
        /// Aggiorna un allegato esistente.
        /// </summary>
        /// <param name="id">ID dell'allegato da aggiornare</param>
        /// <param name="attachmentDto">Nuovi dati dell'allegato</param>
        /// <returns>Conferma aggiornamento</returns>
        /// <response code="204">Allegato aggiornato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="404">Allegato non trovato</response>
        /// <response code="500">Errore interno del server</response>

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAttachment(int id, [FromBody] AllegatoDTO attachmentDto)
        {
            if (id != attachmentDto.All_IDAllegato)
            {
                return BadRequest();
            }

            await _allegatoService.UpdateAsync(attachmentDto);
            return NoContent();
        }


        /// <summary>
        /// Elimina un allegato specifico.
        /// </summary>
        /// <param name="id">ID dell'allegato da eliminare</param>
        /// <returns>Conferma eliminazione</returns>
        /// <response code="204">Allegato eliminato con successo</response>
        /// <response code="404">Allegato non trovato</response>
        /// <response code="500">Errore interno del server</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            await _allegatoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
