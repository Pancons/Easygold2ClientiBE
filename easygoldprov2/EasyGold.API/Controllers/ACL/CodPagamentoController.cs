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
    /// Controller per la gestione delle condizioni di pagamento.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CodPagamentoController : ControllerBase
    {
        private readonly ICodPagamentoService _codPagamentoService;

        public CodPagamentoController(ICodPagamentoService codPagamentoService)
        {
            _codPagamentoService = codPagamentoService;
        }

        /// <summary>
        /// Restituisce una lista di condizioni di pagamento filtrate e paginate.
        /// </summary>
        /// <param name="filter">Filtri di ricerca condizioni di pagamento</param>
        /// <returns>Lista condizioni di pagamento e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<CodPagamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCodPagamentoList([FromBody] CodPagamentoListRequest filter)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var payments = await _codPagamentoService.GetAllAsync(filter, language);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea o aggiorna una condizione di pagamento.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CodPagamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateCodPagamento([FromBody] CodPagamentoDTO dto)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CodPagamentoDTO result;
                if (dto.Cpa_IDAuto > 0)
                {
                    result = await _codPagamentoService.UpdateAsync(dto, language);
                    if (result == null)
                    {
                        return NotFound(new { error = "Condizione di pagamento non trovata" });
                    }
                    return Ok(new BaseResponse<CodPagamentoDTO>(result));
                }
                else
                {
                    result = await _codPagamentoService.AddAsync(dto, language);
                    return CreatedAtAction(nameof(AddOrUpdateCodPagamento), new { id = result.Cpa_IDAuto }, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una condizione di pagamento specifica per ID.
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<CodPagamentoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCodPagamento(int id)
        {
            try
            {
                var language = ExtractLanguageFromToken();
                var result = await _codPagamentoService.GetByIdAsync(id, language);
                if (result == null)
                {
                    return NotFound(new { error = "Condizione di pagamento non trovata" });
                }
                return Ok(new BaseResponse<CodPagamentoDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una condizione di pagamento specifica.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCodPagamento(int id)
        {
            try
            {
                await _codPagamentoService.DeleteAsync(id);
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