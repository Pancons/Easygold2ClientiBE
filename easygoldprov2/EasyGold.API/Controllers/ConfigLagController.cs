using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Config;

namespace EasyGold.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigLagController : ControllerBase
    {
        private readonly IConfigLangService _service;

        public ConfigLagController(IConfigLangService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ConfigLangDTO>), StatusCodes.Status200OK)]
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

        [HttpGet("{isoNum:int}/{id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(ConfigLangDTO), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(ConfigLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] ConfigLangDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { error = "Dati non validi" });

                var existing = await _service.GetByIdAsync(dto.SysLng_ISONum, dto.SysLng_ID);
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

        [HttpDelete("{isoNum:int}/{id:int}")]
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