using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.Web2.Models.Cliente.Anagrafiche;

namespace EasyGold.API.Controllers.Anagrafiche
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImpresaFinanziariaController : ControllerBase
    {
        private readonly IImpresaFinanziariaService _service;

        public ImpresaFinanziariaController(IImpresaFinanziariaService service)
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
                    return NotFound(new { message = "Impresa finanziaria non trovata" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] ImpresaFinanziariaDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ImpresaFinanziariaDTO result;
                if (dto.Imf_IdAuto > 0)
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
                return NotFound(new { message = "Impresa finanziaria non trovata" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}