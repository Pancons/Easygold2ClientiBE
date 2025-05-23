using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.API.Services.Interfaces.GEO;

namespace EasyGold.API.Controllers.GEO
{
    /// <summary>
    /// Controller per la gestione delle traduzioni Stato/Regione.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StatoRegioniLangController : ControllerBase
    {
        private readonly IStatoRegioniLangService _service;

        public StatoRegioniLangController(IStatoRegioniLangService service)
        {
            _service = service;
        }

        /// <summary>
        /// Restituisce tutte le traduzioni Stato/Regione.
        /// </summary>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<StatoRegioniLangDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var results = await _service.GetAllAsync();
            return Ok(results);
        }

        /// <summary>
        /// Restituisce una traduzione Stato/Regione tramite chiave composta.
        /// </summary>
        [HttpGet("{stridISONum}/{stridID}")]
        [Authorize]
        [ProducesResponseType(typeof(StatoRegioniLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int stridISONum, int stridID)
        {
            var result = await _service.GetByIdAsync(stridISONum, stridID);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Crea o aggiorna una traduzione Stato/Regione.
        /// </summary>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(StatoRegioniLangDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] StatoRegioniLangDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StatoRegioniLangDTO result;
            // Se esiste aggiorna, altrimenti crea
            var existing = await _service.GetByIdAsync(dto.StridISONum, dto.StridID);
            if (existing != null)
                result = await _service.UpdateAsync(dto);
            else
                result = await _service.AddAsync(dto);

            return Ok(result);
        }

        /// <summary>
        /// Elimina una traduzione Stato/Regione.
        /// </summary>
        [HttpDelete("{stridISONum}/{stridID}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int stridISONum, int stridID)
        {
            await _service.DeleteAsync(stridISONum, stridID);
            return NoContent();
        }
    }
}