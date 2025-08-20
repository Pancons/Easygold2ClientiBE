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


namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IBrandCatService
    {
        Task<BaseListResponse<BrandCatDTO>> GetAllAsync(BrandCatListRequest request);
        Task<BrandCatDTO> GetByIdAsync(int id);
        Task<BrandCatDTO> AddAsync(BrandCatDTO dto);
        Task<BrandCatDTO> UpdateAsync(BrandCatDTO dto);
        Task DeleteAsync(int id);
    }
}