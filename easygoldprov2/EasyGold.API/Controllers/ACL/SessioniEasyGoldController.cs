
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle sessioni EasyGold.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SessioniEasyGoldController : ControllerBase
    {
        private readonly ISessioniEasyGoldService _sessioniEasyGoldService;

        public SessioniEasyGoldController(ISessioniEasyGoldService sessioniEasyGoldService)
        {
            _sessioniEasyGoldService = sessioniEasyGoldService;
        }

        /// <summary>
        /// Restituisce una lista di sessioni EasyGold filtrate.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<SessioniEasyGoldDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSessioniList([FromBody] SessioniEasyGoldListRequest filter)
        {
            try
            {
                var results = await _sessioniEasyGoldService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una sessione EasyGold.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<SessioniEasyGoldDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateSessione([FromBody] SessioniEasyGoldDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                SessioniEasyGoldDTO result;
                if (dto.Sse_IDAuto > 0)
                {
                    result = await _sessioniEasyGoldService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Sessione non trovata" });
                    }
                    return Ok(new BaseResponse<SessioniEasyGoldDTO>(result));
                }
                else
                {
                    result = await _sessioniEasyGoldService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateSessione), new { id = result.Sse_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una sessione EasyGold specifica per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<SessioniEasyGoldDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSessione(int id)
        {
            try
            {
                var result = await _sessioniEasyGoldService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Sessione non trovata" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una sessione EasyGold specifica.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSessione(int id)
        {
            try
            {
                await _sessioniEasyGoldService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }
    }
}