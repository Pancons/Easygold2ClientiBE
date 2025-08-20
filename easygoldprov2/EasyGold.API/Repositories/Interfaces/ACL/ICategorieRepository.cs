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
using EasyGold.Web2.Models.Cliente.CategorieProdotto;
using EasyGold.Web2.Models.Cliente.Entities.CategorieProdotto;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ICategorieRepository
    {
        Task<(IEnumerable<DbCategorie>, int total)> GetAllAsync(CategorieListRequest filter, string language);
        Task<DbCategorie> GetByIdAsync(int id, string language);
        Task AddAsync(DbCategorie entity, string language);
        Task UpdateAsync(DbCategorie entity, string language);
        Task DeleteAsync(int id);
    }
}