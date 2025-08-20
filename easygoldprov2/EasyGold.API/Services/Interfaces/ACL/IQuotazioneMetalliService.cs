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
    /// <summary>
    /// Provides operations for managing metal quotations.
    /// </summary>
    public interface IQuotazioneMetalliService
    {
        /// <summary>
        /// Retrieves all metal quotations based on a request.
        /// </summary>
        Task<BaseListResponse<QuotazioneMetalliDTO>> GetAllAsync(QuotazioneMetalliListRequest request);

        /// <summary>
        /// Retrieves a metal quotation by its identifier.
        /// </summary>
        Task<QuotazioneMetalliDTO> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new metal quotation.
        /// </summary>
        Task<QuotazioneMetalliDTO> AddAsync(QuotazioneMetalliDTO dto);

        /// <summary>
        /// Updates an existing metal quotation.
        /// </summary>
        Task<QuotazioneMetalliDTO> UpdateAsync(QuotazioneMetalliDTO dto);

        /// <summary>
        /// Deletes a metal quotation by its identifier.
        /// </summary>
        Task DeleteAsync(int id);
    }
}