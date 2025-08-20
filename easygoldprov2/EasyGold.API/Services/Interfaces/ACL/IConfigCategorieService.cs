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
    public interface IConfigCategorieService
    {
        Task<BaseListResponse<ConfigCategorieDTO>> GetAllAsync(ConfigCategorieListRequest request);
        Task<ConfigCategorieDTO> GetByIdAsync(int id);
        Task<ConfigCategorieDTO> AddAsync(ConfigCategorieDTO dto);
        Task<ConfigCategorieDTO> UpdateAsync(ConfigCategorieDTO dto);
        Task DeleteAsync(int id);
    }
}