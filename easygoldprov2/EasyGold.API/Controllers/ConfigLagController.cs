
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.ConfigLag;
using EasyGold.API.Models;

namespace EasyGold.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigLagController : ControllerBase
    {
        private readonly IConfigLagService _service;

        public ConfigLagController(IConfigLagService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ConfigLagDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromBody] BaseListRequest request)
        {
            var response = await _service.GetAllAsync(request);
            return Ok(response);
        }

        [HttpGet("{isoNum:int}/{id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(ConfigLagDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int isoNum, int id)
        {
            var result = await _service.GetByIdAsync(isoNum, id);
            if (result == null)
                return NotFound();
            return Ok(new { result });
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(ConfigLagDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] ConfigLagDTO dto)
        {
            var existing = await _service.GetByIdAsync(dto.Sysid_ISONum, dto.Sysid_ID);
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

        [HttpDelete("{isoNum:int}/{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int isoNum, int id)
        {
            await _service.DeleteAsync(isoNum, id);
            return NoContent();
        }
    }
}