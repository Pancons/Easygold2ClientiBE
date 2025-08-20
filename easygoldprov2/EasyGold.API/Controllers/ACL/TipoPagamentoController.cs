using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei tipi di pagamento.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPagamentoController : ControllerBase
    {
        private readonly ITipoPagamentoService _tipoPagamentoService;

        public TipoPagamentoController(ITipoPagamentoService tipoPagamentoService)
        {
            _tipoPagamentoService = tipoPagamentoService;
        }

        /// <summary>
        /// Restituisce una lista di tipi di pagamento filtrati e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca tipi di pagamento</param>
        /// <returns>Lista tipi di pagamento e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<TipoPagamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoPagamentoList([FromBody] TipoPagamentoListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var pagamenti = await _tipoPagamentoService.GetAllAsync(filter, language);
                return Ok(pagamenti);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna un tipo di pagamento.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoPagamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateTipoPagamento([FromBody] TipoPagamentoDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                TipoPagamentoDTO result;
                if (dto.Tpg_IDAuto > 0)
                {
                    result = await _tipoPagamentoService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Tipo di pagamento non trovato" });
                    }
                    return Ok(new BaseResponse<TipoPagamentoDTO>(result));
                }
                else
                {
                    result = await _tipoPagamentoService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateTipoPagamento), new { id = result.Tpg_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce un tipo di pagamento specifico per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<TipoPagamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoPagamento(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _tipoPagamentoService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Tipo di pagamento non trovato" });
                }
                return Ok(new BaseResponse<TipoPagamentoDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un tipo di pagamento specifico.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTipoPagamento(int id)
        {
            try
            {
                await _tipoPagamentoService.DeleteAsync(id);
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

        /// <summary>
        /// Estrae la lingua dal token di refresh.
        /// </summary>
        /// <returns>Codice della lingua</returns>
        private string ExtractLanguageFromToken()
        {
            string refreshToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            string language = "en"; // default language

            if (!string.IsNullOrEmpty(refreshToken))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(refreshToken) as JwtSecurityToken;

                language = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "language")?.Value ?? "en";
            }

            return language;
        }
    }
}