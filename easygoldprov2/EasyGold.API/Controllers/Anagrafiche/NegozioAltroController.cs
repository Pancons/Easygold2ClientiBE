using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.API.Services.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.Anagrafiche
{
    [ApiController]
    [Route("api/[controller]")]
    public class NegozioAltroController : ControllerBase
    {
        private readonly INegoziAltroService _service;

        public NegozioAltroController(INegoziAltroService service)
        {
            _service = service;
        }

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<NegozioAltroDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromBody] NegozioAltroListRequest filter)
        {
            try
            {
                var results = await _service.GetAllAsync(filter);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NegozioAltroDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound(new { message = "Informazioni aggiuntive negozio non trovate" });
                return Ok(new BaseResponse<NegozioAltroDTO>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<NegozioAltroDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] NegozioAltroDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                NegozioAltroDTO result;
                if (dto.Id > 0)
                    result = await _service.UpdateAsync(dto);
                else
                    result = await _service.AddAsync(dto);

                return Ok(new BaseResponse<NegozioAltroDTO>(result));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                return NotFound(new { message = "Informazioni aggiuntive negozio non trovate" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}