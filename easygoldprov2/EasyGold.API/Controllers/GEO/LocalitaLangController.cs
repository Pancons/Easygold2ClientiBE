using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Comune.ACL;

namespace EasyGold.API.Controllers.GEO
{
    /// <summary>
    /// Controller per la gestione delle traduzioni Località.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LocalitaLangController : ControllerBase
    {
        private readonly ILocalitaLangService _service;

        public LocalitaLangController(ILocalitaLangService service)
        {
            _service = service;
        }

        /// <summary>
        /// Restituisce tutte le traduzioni Località.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<LocalitaLangDTO>), StatusCodes.Status200OK)]
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
        /// Restituisce una traduzione Località tramite chiave composta.
        /// </summary>
        [HttpGet("{stridISONum}/{stridID}")]
        [Authorize]
        [ProducesResponseType(typeof(LocalitaLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int stridISONum, int stridID)
        {
            try
            {
                var result = await _service.GetByIdAsync(stridISONum, stridID);
                if (result == null)
                    return NotFound(new { message = "Traduzione Località non trovata" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una traduzione Località.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(LocalitaLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] LocalitaLangDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                LocalitaLangDTO result;
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
        /// Elimina una traduzione Località.
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
                return NotFound(new { message = "Traduzione Località non trovata" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}