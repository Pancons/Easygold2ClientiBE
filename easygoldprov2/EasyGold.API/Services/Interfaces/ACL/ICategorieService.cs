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


namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ICategorieService
    {
        Task<BaseListResponse<CategorieDTO>> GetAllAsync(CategorieListRequest filter, string language);
        Task<CategorieDTO> GetByIdAsync(int id, string language);
        Task<CategorieDTO> AddAsync(CategorieDTO dto, string language);
        Task<CategorieDTO> UpdateAsync(CategorieDTO dto, string language);
        Task DeleteAsync(int id);
    }
}