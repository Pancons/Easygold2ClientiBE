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
    public interface IMetalliService
    {
         /// <summary>
        /// Retrieves a list of metals with pagination and filtering.
        /// </summary>
        /// <param name="filter">Filter criteria for metals</param>
        /// <param name="language">Language code for localization</param>
        Task<BaseListResponse<MetalliDTO>> GetAllAsync(MetalliListRequest filter, string language);

        /// <summary>
        /// Retrieves a specific metal by ID.
        /// </summary>
        /// <param name="id">ID of the metal</param>
        /// <param name="language">Language code for localization</param>
        Task<MetalliDTO> GetByIdAsync(int id, string language);

        /// <summary>
        /// Adds a new metal.
        /// </summary>
        /// <param name="dto">DTO of the metal</param>
        /// <param name="language">Language code for localization</param>
        Task<MetalliDTO> AddAsync(MetalliDTO dto, string language);

        /// <summary>
        /// Updates an existing metal.
        /// </summary>
        /// <param name="dto">DTO of the metal</param>
        /// <param name="language">Language code for localization</param>
        Task<MetalliDTO> UpdateAsync(MetalliDTO dto, string language);

        /// <summary>
        /// Deletes a metal by ID.
        /// </summary>
        /// <param name="id">ID of the metal</param>
        Task DeleteAsync(int id);
    }
}