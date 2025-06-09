using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ConfigProgramma;
using EasyGold.API.Services.Interfaces.ConfigProgramma;

namespace EasyGold.API.Controllers.ConfigProgramma
{
    /// <summary>
    /// Controller per la gestione dei moduli.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ModuliController : ControllerBase
    {
        private readonly IModuloService _moduloService; // 🔹 Usa il servizio invece del repository

        public ModuliController(IModuloService moduloService)
        {
            _moduloService = moduloService;
        }

        /// <summary>
        /// Restituisce l'elenco dei moduli per il dropdown.
        /// </summary>
        /// <returns>Lista di moduli</returns>
        /// <response code="200">Moduli restituiti con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<ModuloDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModulesList()
        {
            try
            {
                var results = await _moduloService.GetAllAsync();
                if (results == null || results.total == 0)
                {
                    return NotFound(new { message = "Nessun modulo disponibile" });
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }



    }
}
