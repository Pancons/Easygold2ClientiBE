
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Services;
using EasyGold.API.Services.Implementations;
using EasyGold.API.Services.Interfaces;
using EasyGold.API.Models.Nazioni;
using EasyGold.API.Models;
using EasyGold.API.Models.Variabili;


namespace EasyGold.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ValoriTabelleController : ControllerBase
    {
        private readonly IValoriTabelleService _service;

        public ValoriTabelleController(IValoriTabelleService service)
        {
            _service = service;
        }

        [HttpPost("find")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<ValoriTabelleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Find([FromBody] ValoriTabelleDTO request)
        {
            if (string.IsNullOrEmpty(request.LstItemType))
                return BadRequest("Il parametro lst_itemType è obbligatorio.");

            var result = await _service.FindAsync(request.LstItemType);
            return Ok(result);
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(ValoriTabelleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody] ValoriTabelleDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.SaveAsync(dto);
            return Ok(result);
        }
    }
}