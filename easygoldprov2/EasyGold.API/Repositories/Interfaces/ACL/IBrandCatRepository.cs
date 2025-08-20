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

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IBrandCatRepository
    {
        Task<(IEnumerable<DbBrandCat> items, int total)> GetAllAsync(BrandCatListRequest request);
        Task<DbBrandCat> GetByIdAsync(int id);
        Task AddAsync(DbBrandCat entity);
        Task<DbBrandCat> UpdateAsync(DbBrandCat entity);
        Task DeleteAsync(int id);
    }
}