using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Repositories.Implementations;
using EasyGold.API.Services.Implementations;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.API.Services.Interfaces.ACL;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione dei ruoli.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RuoliController : ControllerBase
    {
        private readonly IRuoloService _roleService;

        public RuoliController(IRuoloService RoleService)
        {
            _roleService = RoleService;
        }

        /// <summary>
        /// Restituisce tutti i ruoli disponibili.
        /// </summary>
        /// <returns>Lista di ruoli</returns>
        /// <response code="200">Ruoli restituiti con successo</response>
        /// <response code="500">Errore interno del server</response>

        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<RuoloDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                // Retrieve roles from the database
                var results = await _roleService.GetAllRolesAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
