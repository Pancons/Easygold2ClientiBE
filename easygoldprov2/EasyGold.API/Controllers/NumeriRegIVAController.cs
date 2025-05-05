using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.NumeriRegIVA;
using EasyGold.API.Models;

namespace EasyGold.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumeriRegIVAController : ControllerBase
    {
        private readonly INumeriRegIVAService _service;

        public NumeriRegIVAController(INumeriRegIVAService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<NumeriRegIVADTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromBody] BaseListRequest request)
        {
            var response = await _service.GetAllAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(NumeriRegIVADTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(new { result });
        }

        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> Save([FromBody] NumeriRegIVADTO dto)
        {
            if (dto.RowIDAuto.HasValue && dto.RowIDAuto > 0)
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

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}