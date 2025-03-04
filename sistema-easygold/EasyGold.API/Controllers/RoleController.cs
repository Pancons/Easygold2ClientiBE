using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Roles;
using EasyGold.API.Repositories.Implementations;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;

namespace EasyGold.API.Controllers
{
    /// <summary>
    /// Controller per la gestione dei ruoli.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService RoleService)
        {
            _roleService = RoleService;
        }

        /// <summary>
        /// Restituisce tutti i ruoli disponibili.
        /// </summary>
        /// <returns>Lista di ruoli</returns>
        /// <response code="200">Ruoli restituiti con successo</response>
        /// <response code="500">Errore interno del server</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                // Retrieve roles from the database
                var roles = await _roleService.GetAllRolesAsync();
                return Ok(new { roles });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
