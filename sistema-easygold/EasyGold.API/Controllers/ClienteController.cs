using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Clients;
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
        public async Task<IActionResult> List([FromBody] ClienteListRequest request)
        {
            try
            {
                var result = await _clienteService.GetClientiListAsync(request);
                return Ok(new { clienti = result.Clienti, total = result.Total });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Salva un nuovo cliente con i dettagli forniti.
        /// </summary>
        /// <param name="clienteDto">Dati del cliente da salvare</param>
        /// <returns>Cliente creato</returns>
        /// <response code="200">Cliente salvato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("save")]
        public async Task<IActionResult> SaveClient([FromForm] ClienteDettaglioDTO clienteDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (clienteDto == null)
                    return BadRequest(new { error = "Errore nei dati inviati" });

                var cliente = await _clienteService.CreateClienteAsync(clienteDto);
                return Ok(new { cliente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }


        /// <summary>
        /// Aggiorna un cliente esistente con i dati forniti.
        /// </summary>
        /// <param name="id">ID del cliente da aggiornare</param>
        /// <param name="clienteDto">Nuovi dati del cliente</param>
        /// <returns>Cliente aggiornato</returns>
        /// <response code="200">Cliente aggiornato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="404">Cliente non trovato</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromForm] ClienteDettaglioDTO clienteDto)
        {
            try
            {

                 if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                if (clienteDto == null)
                    return BadRequest(new { error = "Errore nei dati inviati" });

                var clienteAggiornato = await _clienteService.UpdateClienteAsync(id, clienteDto);
                if (clienteAggiornato == null)
                    return NotFound(new { error = "Cliente non trovato" });

                return Ok(new { cliente = clienteAggiornato });
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
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clienteService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(new { client });
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
