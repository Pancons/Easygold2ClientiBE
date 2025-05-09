using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;
using EasyGold.API.Models.DTO.Config;

namespace EasyGold.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _service;

        public ConfigController(IConfigService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ConfigDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromBody] BaseListRequest request)
        {
            var response = await _service.GetAllAsync(request);
            return Ok(response);
        }

        [HttpGet("config/{idNazione}")]
        [Authorize]
        [ProducesResponseType(typeof(ConfigResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetConfig(int idNazione)
        {
            try
            {
                var response = await _service.GetParametriConfigurazione(idNazione);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ConfigDTO), StatusCodes.Status200OK)]
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
        public async Task<IActionResult> Save([FromBody] ConfigDTO dto)
        {
            if (dto.Sys_IDAuto.HasValue && dto.Sys_IDAuto > 0)
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