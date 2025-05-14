using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;

namespace EasyGold.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GruppiController : ControllerBase
    {
        private readonly IGruppiService _service;

        public GruppiController(IGruppiService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<GruppiDTO>), StatusCodes.Status200OK)]
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

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(GruppiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
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
        [ProducesResponseType(typeof(GruppiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] GruppiDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { error = "Dati non validi" });

                if (dto.Gru_IDGruppo.HasValue && dto.Gru_IDGruppo > 0)
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

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}