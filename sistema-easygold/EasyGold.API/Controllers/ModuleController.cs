using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione dei moduli.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuloService _moduloService; // 🔹 Usa il servizio invece del repository

        public ModuleController(IModuloService moduloService)
        {
            _moduloService = moduloService;
        }

        /// <summary>
        /// Restituisce l'elenco dei moduli per il dropdown.
        /// </summary>
        /// <returns>Lista di moduli</returns>
        /// <response code="200">Moduli restituiti con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet("dropdown")]
        [Authorize]
        public async Task<IActionResult> GetModulesDropdown()
        {
            // Usa il servizio per ottenere i moduli
            var modules = await _moduloService.GetAllAsync();
            return Ok(new { modules });
        }



    }
}
