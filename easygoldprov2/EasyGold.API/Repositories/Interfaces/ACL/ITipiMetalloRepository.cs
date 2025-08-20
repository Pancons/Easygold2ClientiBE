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

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ITipiMetalloRepository
    {
        /// <summary>
        /// Retrieves a list of metal types with pagination and filtering options.
        /// </summary>
        /// <param name="filter">Filter criteria for metal types</param>
        /// <param name="language">Language code for localization</param>
        Task<(IEnumerable<DbTipiMetallo>, int total)> GetAllAsync(TipiMetalloListRequest filter, string language);

        /// <summary>
        /// Retrieves a specific metal type by ID and language.
        /// </summary>
        /// <param name="id">ID of the metal type</param>
        /// <param name="language">Language code for localization</param>
        Task<DbTipiMetallo> GetByIdAsync(int id, string language);

        /// <summary>
        /// Adds a new metal type with support for language-specific data.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <param name="language">Language code for localization</param>
        Task AddAsync(DbTipiMetallo entity, string language);

        /// <summary>
        /// Updates an existing metal type with language-specific data.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="language">Language code for localization</param>
        Task UpdateAsync(DbTipiMetallo entity, string language);

        /// <summary>
        /// Deletes a metal type by its ID.
        /// </summary>
        /// <param name="id">ID of the metal type</param>
        Task DeleteAsync(int id);
    }
}