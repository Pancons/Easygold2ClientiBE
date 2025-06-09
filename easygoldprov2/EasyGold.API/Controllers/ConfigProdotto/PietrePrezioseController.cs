using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Cliente.ConfigProdotto;

namespace EasyGold.API.Controllers.ConfigProdotto
{
    [ApiController]
    [Route("api/[controller]")]
    public class PietrePrezioseController : ControllerBase
    {
        private readonly IPietrePrezioseService _service;

        public PietrePrezioseController(IPietrePrezioseService service)
        {
            _service = service;
        }

        [HttpPost("list")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound(new { message = "Pietra preziosa non trovata" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] PietraPreziosaDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                PietraPreziosaDTO result;
                if (dto.Ppz_IdAuto > 0)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Pietra preziosa non trovata" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}