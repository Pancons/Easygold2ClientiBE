using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Services;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;

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
        public async Task<IActionResult> GetUsersList([FromBody] UserFilterDTO filter)
        {
            try
            {
                var result = await _utenteService.GetUsersListAsync(filter);
                return Ok(new { utenti = result.Users, total = result.Total });
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
        [HttpPost]
        [AllowAnonymous]
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
                    var user = await _utenteService.UpdateAsync(userDto);
                    if (user == null)
                    {
                        return NotFound(new { error = "Utente non trovato" });
                    }
                    return Ok(new { user }); // Restituisce l'utente aggiornato con codice 200
                }
                else // Se non ha un ID, crea un nuovo utente
                {
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
        /// Restituisce un utente per ID.
        /// </summary>
        /// <param name="id">ID dell'utente</param>
        /// <returns>Dettagli dell'utente</returns>
        /// <response code="200">Utente trovato</response>
        /// <response code="404">Utente non trovato</response>
        /// <response code="500">Errore interno</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _utenteService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { error = "Utente non trovato" });
                }
                return Ok(new { user });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }

            
        }



        /*
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _utenteService.GetAllAsync();
            
            return Ok(new { users });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _utenteService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new { user });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUser([FromBody] UtenteDettaglioDTO userDto)
        {
            await _utenteService.AddAsync(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = userDto.Utw_IDUtente }, userDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UtenteDettaglioDTO userDto)
        {
            if (id != userDto.Utw_IDUtente)
            {
                return BadRequest();
            }

            await _utenteService.UpdateAsync(userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _utenteService.DeleteAsync(id);
            return NoContent();
        }
        */
    }
}