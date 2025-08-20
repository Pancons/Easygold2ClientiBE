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
    public interface IQuotazioneMetalliRepository
    {
        /// <summary>
        /// Retrieves all metal quotations with pagination and filtering options.
        /// </summary>
        Task<(IEnumerable<DbQuotazioneMetalli> items, int total)> GetAllAsync(QuotazioneMetalliListRequest request);

        /// <summary>
        /// Retrieves a metal quotation by its ID.
        /// </summary>
        Task<DbQuotazioneMetalli> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new metal quotation.
        /// </summary>
        Task AddAsync(DbQuotazioneMetalli dto);

        /// <summary>
        /// Updates an existing metal quotation.
        /// </summary>
        Task<DbQuotazioneMetalli> UpdateAsync(DbQuotazioneMetalli dto);

        /// <summary>
        /// Deletes a metal quotation by its ID.
        /// </summary>
        Task DeleteAsync(int id);
    }
}