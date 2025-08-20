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
    public interface IMetalliRepository
    {
        /// <summary>
        /// Retrieves a paginated and filtered list of metals.
        /// </summary>
        /// <param name="filter">Filter criteria for metals</param>
        /// <param name="language">Language code for localization</param>
        Task<(IEnumerable<DbMetalli>, int total)> GetAllAsync(MetalliListRequest filter, string language);

        /// <summary>
        /// Retrieves a specific metal by its ID.
        /// </summary>
        /// <param name="id">ID of the metal</param>
        /// <param name="language">Language code for localization</param>
        Task<DbMetalli> GetByIdAsync(int id, string language);

        /// <summary>
        /// Adds a new metal.
        /// </summary>
        /// <param name="entity">The metal entity to add</param>
        /// <param name="language">Language code for localization</param>
        Task AddAsync(DbMetalli entity, string language);

        /// <summary>
        /// Updates an existing metal.
        /// </summary>
        /// <param name="entity">The metal entity to update</param>
        /// <param name="language">Language code for localization</param>
        Task UpdateAsync(DbMetalli entity, string language);

        /// <summary>
        /// Deletes a metal by its ID.
        /// </summary>
        /// <param name="id">ID of the metal</param>
        Task DeleteAsync(int id);
    }
}