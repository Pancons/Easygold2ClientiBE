using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.API.Services.Interfaces.ConfigProdotto;

namespace EasyGold.API.Controllers.ConfigProdotto
{
    /// <summary>
    /// Controller per la gestione delle traduzioni Tipi Metallo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipiMetalloLangController : ControllerBase
    {
        private readonly ITipiMetalloLangService _service;

        public TipiMetalloLangController(ITipiMetalloLangService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TipiMetalloLangDTO>), StatusCodes.Status200OK)]
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

        [HttpGet("{timidISONum}/{timidID}")]
        [Authorize]
        [ProducesResponseType(typeof(TipiMetalloLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int timidISONum, int timidID)
        {
            try
            {
                var result = await _service.GetByIdAsync(timidISONum, timidID);
                if (result == null)
                    return NotFound(new { message = "Traduzione Tipo Metallo non trovata" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(TipiMetalloLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] TipiMetalloLangDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                TipiMetalloLangDTO result;
                var existing = await _service.GetByIdAsync(dto.Timid_ISONum, dto.Timid_ID);
                if (existing != null)
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

        [HttpDelete("{timidISONum}/{timidID}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int timidISONum, int timidID)
        {
            try
            {
                await _service.DeleteAsync(timidISONum, timidID);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Traduzione Tipo Metallo non trovata" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}