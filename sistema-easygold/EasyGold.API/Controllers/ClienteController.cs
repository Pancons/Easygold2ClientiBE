using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Clienti;
using EasyGold.API.Services;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;



namespace EasyGold.API.Controllers
{

    /// <summary>
    /// Controller per la gestione dei clienti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }



        /// <summary>
        /// Restituisce una lista di clienti con filtri e paginazione.
        /// </summary>
        /// <param name="request">Filtri e parametri di paginazione</param>
        /// <returns>Lista clienti e totale</returns>
        /// <response code="200">Lista clienti restituita</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List([FromBody] ClienteListRequest request)
        {
            try
            {
                request ??= new ClienteListRequest(); // Se la richiesta è nulla, crea un oggetto vuoto

                var result = await _clienteService.GetClientiListAsync(request);
                return Ok(new { result = result.Clienti, total = result.Total });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Salva un nuovo cliente o aggiorna un cliente esistente con i dettagli forniti.
        /// </summary>
        /// <param name="clienteDto">Dati del cliente da salvare o aggiornare</param>
        /// <returns>Cliente creato o aggiornato</returns>
        /// <response code="200">Cliente salvato o aggiornato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="404">Cliente non trovato (solo in caso di aggiornamento)</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(ClienteDettaglioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        public async Task<IActionResult> SaveClient([FromBody] ClienteDettaglioDTO clienteDto)
        {
            try
            {
                if (clienteDto == null)
                {
                    return BadRequest(new { error = "Errore nei dati inviati" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (clienteDto.Utw_IDClienteAuto > 0) // Se ha un ID valido, esegue l'aggiornamento
                {
                    var clienteAggiornato = await _clienteService.UpdateClienteAsync(clienteDto.Utw_IDClienteAuto, clienteDto);
                    if (clienteAggiornato == null)
                    {
                        return NotFound(new { error = "Cliente non trovato" });
                    }

                    return Ok(new { cliente = clienteAggiornato });
                }
                else // Altrimenti, crea un nuovo cliente
                {
                    Console.WriteLine($"DTO ricevuto - Moduli: {clienteDto.Moduli?.Count}, Allegati: {clienteDto.Allegati?.Count}, Negozi: {clienteDto.Negozi?.Count}");

                    var cliente = await _clienteService.CreateClienteAsync(clienteDto);
                    return Ok(new { cliente });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }


        /// <summary>
        /// Restituisce i dettagli di un cliente specifico.
        /// </summary>
        /// <param name="id">ID del cliente</param>
        /// <returns>Dettagli del cliente</returns>
        /// <response code="200">Dettagli cliente restituiti</response>
        /// <response code="404">Cliente non trovato</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ClienteDettaglioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClient(int id)
        {
            var result = await _clienteService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { result });
        }


        /// <summary>
        /// Elimina un Cliente specifico.
        /// </summary>
        /// <param name="id">ID del cliente da eliminare</param>
        /// <returns>Conferma eliminazione</returns>
        /// <response code="204">Cliente eliminato con successo</response>
        /// <response code="404">Cliente non trovato</response>
        /// <response code="500">Errore interno del server</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }

        /*
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddClient([FromBody] ClienteDettaglioDTO clientDto)
        {
            await _clienteService.AddAsync(clientDto);
            return CreatedAtAction(nameof(GetClient), new { id = clientDto.Utw_IDClienteAuto }, clientDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClienteDettaglioDTO clientDto)
        {
            if (id != clientDto.Utw_IDClienteAuto)
            {
                return BadRequest();
            }

            await _clienteService.UpdateAsync(clientDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
        */

    }
}
