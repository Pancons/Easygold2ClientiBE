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
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;


namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ITipiMetalloService
    {
        /// <summary>
        /// Retrieves a list of metal types with pagination and filtering.
        /// </summary>
        /// <param name="filter">Filter criteria for metal types</param>
        /// <param name="language">Language code for localization</param>
        Task<BaseListResponse<TipiMetalloDTO>> GetAllAsync(TipiMetalloListRequest filter, string language);

        /// <summary>
        /// Retrieves a specific metal type by ID.
        /// </summary>
        /// <param name="id">ID of the metal type</param>
        /// <param name="language">Language code for localization</param>
        Task<TipiMetalloDTO> GetByIdAsync(int id, string language);

        /// <summary>
        /// Adds a new metal type.
        /// </summary>
        /// <param name="dto">DTO of the metal type</param>
        /// <param name="language">Language code for localization</param>
        Task<TipiMetalloDTO> AddAsync(TipiMetalloDTO dto, string language);

        /// <summary>
        /// Updates an existing metal type.
        /// </summary>
        /// <param name="dto">DTO of the metal type</param>
        /// <param name="language">Language code for localization</param>
        Task<TipiMetalloDTO> UpdateAsync(TipiMetalloDTO dto, string language);

        /// <summary>
        /// Deletes a metal type by ID.
        /// </summary>
        /// <param name="id">ID of the metal type</param>
        Task DeleteAsync(int id);
    }
}