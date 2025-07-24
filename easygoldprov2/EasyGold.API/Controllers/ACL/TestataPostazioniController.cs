using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle testate postazioni.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestataPostazioniController : ControllerBase
    {
        private readonly ITestataPostazioniService _testataPostazioniService;

        public TestataPostazioniController(ITestataPostazioniService testataPostazioniService)
        {
            _testataPostazioniService = testataPostazioniService;
        }

        /// <summary>
        /// Restituisce una lista di testate postazioni filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca testate postazioni</param>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TestataPostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTestataPostazioniList([FromBody] TestataPostazioniListRequest filter)
        {
            try
            {
                var results = await _testataPostazioniService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova testata postazioni o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della testata postazioni</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TestataPostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTestataPostazione([FromBody] TestataPostazioniDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.tpo_IDAuto > 0)
                {
                    var result = await _testataPostazioniService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Postazione non trovata" });
                    }
                    return Ok(new BaseResponse<TestataPostazioniDTO>(result));
                }
                else
                {
                    var newPostazione = await _testataPostazioniService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateTestataPostazione), new { id = newPostazione.tpo_IDAuto }, newPostazione);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una testata postazione per ID.
        /// </summary>
        /// <param name="id">ID della postazione</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TestataPostazioniDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTestataPostazione(int id)
        {
            try
            {
                var result = await _testataPostazioniService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Postazione non trovata" });
                }
                return Ok(new BaseResponse<TestataPostazioniDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una testata postazione specifica.
        /// </summary>
        /// <param name="id">ID della postazione da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTestataPostazione(int id)
        {
            try
            {
                await _testataPostazioniService.DeleteAsync(id);
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
