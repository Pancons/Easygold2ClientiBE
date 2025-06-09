using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.API.Services.Interfaces.GEO;

namespace EasyGold.API.Controllers.GEO
{
    /// <summary>
    /// Controller per la gestione delle traduzioni Indirizzi.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IndirizziLangController : ControllerBase
    {
        private readonly IIndirizziLangService _service;

        public IndirizziLangController(IIndirizziLangService service)
        {
            _service = service;
        }

        /// <summary>
        /// Restituisce tutte le traduzioni Indirizzi.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<IndirizziLangDTO>), StatusCodes.Status200OK)]
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

        /// <summary>
        /// Restituisce una traduzione Indirizzo tramite chiave composta.
        /// </summary>
        [HttpGet("{stridISONum}/{stridID}")]
        [Authorize]
        [ProducesResponseType(typeof(IndirizziLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int stridISONum, int stridID)
        {
            try
            {
                var result = await _service.GetByIdAsync(stridISONum, stridID);
                if (result == null)
                    return NotFound(new { message = "Traduzione Indirizzo non trovata" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una traduzione Indirizzo.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(IndirizziLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] IndirizziLangDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                IndirizziLangDTO result;
                var existing = await _service.GetByIdAsync(dto.StridISONum, dto.StridID);
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

        /// <summary>
        /// Elimina una traduzione Indirizzo.
        /// </summary>
        [HttpDelete("{stridISONum}/{stridID}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int stridISONum, int stridID)
        {
            try
            {
                await _service.DeleteAsync(stridISONum, stridID);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Traduzione Indirizzo non trovata" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}