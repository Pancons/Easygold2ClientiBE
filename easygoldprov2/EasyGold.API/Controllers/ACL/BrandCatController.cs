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
using EasyGold.Web2.Models.Cliente.Brand;
using EasyGold.Web2.Models.Cliente.Entities.Brand;

namespace EasyGold.API.Controllers.ACL
{
    /// <summary>
    /// Controller per la gestione delle categorie di brand.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BrandCatController : ControllerBase
    {
        private readonly IBrandCatService _brandCatService;

        public BrandCatController(IBrandCatService brandCatService)
        {
            _brandCatService = brandCatService;
        }

        /// <summary>
        /// Restituisce una lista di categorie di brand filtrate e paginati.
        /// </summary>
        /// <param name="filter">Filtri di ricerca categorie</param>
        /// <returns>Lista categorie di brand e totale</returns>
        [HttpPost("list")]
        [Authorize]
        [ProducesResponseType(typeof(BaseListResponse<BrandCatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBrandCatList([FromBody] BrandCatListRequest filter)
        {
            try
            {
                var results = await _brandCatService.GetAllAsync(filter);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nuova categoria di brand o aggiorna una esistente.
        /// </summary>
        /// <param name="dto">Dati della categoria di brand</param>
        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<BrandCatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateBrandCat([FromBody] BrandCatDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Brc_IDAuto > 0)
                {
                    var result = await _brandCatService.UpdateAsync(dto);
                    if (result == null)
                    {
                        return NotFound(new { error = "Categoria non trovata" });
                    }
                    return Ok(new BaseResponse<BrandCatDTO>(result));
                }
                else
                {
                    var newCategory = await _brandCatService.AddAsync(dto);
                    return CreatedAtAction(nameof(AddOrUpdateBrandCat), new { id = newCategory.Brc_IDAuto }, newCategory);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Restituisce una categoria di brand per ID.
        /// </summary>
        /// <param name="id">ID della categoria</param>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse<BrandCatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBrandCat(int id)
        {
            try
            {
                var result = await _brandCatService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { error = "Categoria non trovata" });
                }
                return Ok(new BaseResponse<BrandCatDTO>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Errore interno", ex = ex.Message });
            }
        }

        /// <summary>
        /// Elimina una categoria di brand specifica.
        /// </summary>
        /// <param name="id">ID della categoria di brand da eliminare</param>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBrandCat(int id)
        {
            try
            {
                await _brandCatService.DeleteAsync(id);
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