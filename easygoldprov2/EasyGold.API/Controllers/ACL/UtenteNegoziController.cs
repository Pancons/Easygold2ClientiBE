using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle associazioni Utente-Negozi.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UtenteNegoziController : ControllerBase
    {
        private readonly IUtenteNegoziService _service;

        public UtenteNegoziController(IUtenteNegoziService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<UtenteNegoziDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _service.GetAllAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UtenteNegoziDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound(new { message = "Associazione utente-negozio non trovata" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(UtenteNegoziDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] UtenteNegoziDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UtenteNegoziDTO result;
                if (dto.Utn_ID > 0)
                    result = await _service.UpdateAsync(dto);
                else
                    result = await _service.AddAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Associazione utente-negozio non trovata" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}