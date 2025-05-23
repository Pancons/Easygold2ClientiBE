using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;
using EasyGold.API.Services.Interfaces.ConfigData;

namespace EasyGold.API.Controllers.ConfigData
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardLangController : ControllerBase
    {
        private readonly ICreditCardLangService _service;

        public CreditCardLangController(ICreditCardLangService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<CreditCardLangDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromBody] BaseListRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest(new { error = "Richiesta non valida" });

                var response = await _service.GetAllAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{isoNum}/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CreditCardLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int isoNum, int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(isoNum, id);
                if (result == null)
                    return NotFound();
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(CreditCardLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] CreditCardLangDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { error = "Dati non validi" });

                var existing = await _service.GetByIdAsync(dto.Crcid_ISONum, dto.Crcid_ID);
                if (existing != null)
                {
                    var updated = await _service.UpdateAsync(dto);
                    return Ok(new { result = updated });
                }
                else
                {
                    var created = await _service.AddAsync(dto);
                    return Ok(new { result = created });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{isoNum}/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int isoNum, int id)
        {
            try
            {
                await _service.DeleteAsync(isoNum, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}