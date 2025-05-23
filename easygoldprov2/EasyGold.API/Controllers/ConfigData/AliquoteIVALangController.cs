using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.API.Services.Interfaces.ConfigData;

namespace EasyGold.API.Controllers.ConfigData
{
    [ApiController]
    [Route("api/[controller]")]
    public class AliquoteIVALangController : ControllerBase
    {
        private readonly IAliquoteIVALangService _service;

        public AliquoteIVALangController(IAliquoteIVALangService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<AliquoteIVALangDTO>), StatusCodes.Status200OK)]
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

        [HttpGet("{isonum}/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(AliquoteIVALangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int isonum, int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(isonum, id);
                if (result == null)
                    return NotFound(new { message = "Traduzione Aliquota IVA non trovata" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(AliquoteIVALangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] AliquoteIVALangDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                AliquoteIVALangDTO result;
                var existing = await _service.GetByIdAsync(dto.Ivaid_ISONum, dto.Ivaid_ID);
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

        [HttpDelete("{isonum}/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int isonum, int id)
        {
            try
            {
                await _service.DeleteAsync(isonum, id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Traduzione Aliquota IVA non trovata" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}