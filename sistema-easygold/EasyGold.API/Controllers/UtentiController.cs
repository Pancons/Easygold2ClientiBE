using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Services;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Models;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione degli utenti.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UtentiController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtentiController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }


        /// <summary>
        /// Restituisce una lista di utenti filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca utenti</param>
        /// <returns>Lista utenti e totale</returns>
        /// <response code="200">Lista utenti restituita con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [ProducesResponseType(typeof(BaseListResponse<UtenteDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersList([FromBody] UtentiListRequest filter)
        {
            try
            {
                var results = await _utenteService.GetUsersListAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo utente o aggiorna un utente esistente nel sistema.
        /// </summary>
        /// <param name="userDto">Dati dell'utente da creare o aggiornare</param>
        /// <returns>Utente creato o aggiornato</returns>
        /// <response code="201">Utente creato con successo</response>
        /// <response code="200">Utente aggiornato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="404">Utente non trovato (in caso di aggiornamento)</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("save")]
        [AllowAnonymous]   
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        public async Task<IActionResult> AddOrUpdateUser([FromBody] UtenteDTO userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (userDto == null)
                {
                    return BadRequest(new { error = "Dati non validi" });
                }

                if (userDto.Ute_IDUtente > 0) // Se ha un ID, esegue l'aggiornamento
                {
                    var result = await _utenteService.UpdateAsync(userDto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Utente non trovato" });
                    }
                    return Ok(new { result }); // Restituisce l'utente aggiornato con codice 200
                }
                else // Se non ha un ID, crea un nuovo utente
                {
                    var result = await _utenteService.UsernameExist(userDto);
                    if (result)
                    {
                        return BadRequest(new { error = "Username già presente" });
                    }

                    var newUser = await _utenteService.AddAsync(userDto);
                    return CreatedAtAction(nameof(AddOrUpdateUser), new { id = newUser.Ute_IDUtente }, newUser);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuovo utente o aggiorna un utente esistente nel sistema.
        /// </summary>
        /// <param name="userDto">Dati dell'utente da creare o aggiornare</param>
        /// <returns>Utente creato o aggiornato</returns>
        /// <response code="201">Utente creato con successo</response>
        /// <response code="200">Utente aggiornato con successo</response>
        /// <response code="400">Errore nei dati inviati</response>
        /// <response code="404">Utente non trovato (in caso di aggiornamento)</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("changepassword")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordDTO passwordDto)
        {
            try
            {
                if (passwordDto == null)
                {
                    return BadRequest(new { error = "Dati non validi" });
                }

                if (passwordDto.Ute_IDUtente > 0) // Se ha un ID, verifico se l'utente esiste
                {
                    var result = await _utenteService.GetUserByIdAsync(passwordDto.Ute_IDUtente);
                    if (result == null)
                    {
                        return NotFound(new { error = "Utente non trovato" });
                    }
                    if (_utenteService.AuthenticateAsync(result.Ute_NomeUtente, passwordDto.Ute_OldPassword).Result == null)
                    {
                        return BadRequest(new { error = "La vecchia password non è corretta" });
                    }
                    if (!_utenteService.ChangePassword(passwordDto).Result)
                    {
                        return BadRequest(new { error = "Si è verificato un errore durante l'aggiornamento della password" });
                    }
                    return Ok(new { result }); // Restituisce l'utente aggiornato con codice 200
                }
                else // Se non ha un ID, crea un nuovo utente
                {
                    return BadRequest(new { error = "ID Utente non valido" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un utente per ID.
        /// </summary>
        /// <param name="id">ID dell'utente</param>
        /// <returns>Dettagli dell'utente</returns>
        /// <response code="200">Utente trovato</response>
        /// <response code="404">Utente non trovato</response>
        /// <response code="500">Errore interno</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UtenteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var result = await _utenteService.GetUserByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Utente non trovato" });
                }
                return Ok(new { result });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }

            
        }

        /// <summary>
        /// Elimina un Utente specifico.
        /// </summary>
        /// <param name="id">ID del Utente da eliminare</param>
        /// <returns>Conferma eliminazione</returns>
        /// <response code="204">Utente eliminato con successo</response>
        /// <response code="404">Utente non trovato</response>
        /// <response code="500">Errore interno del server</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUtente(int id)
        {
            await _utenteService.DeleteAsync(id);
            return NoContent();
        }
    }
}