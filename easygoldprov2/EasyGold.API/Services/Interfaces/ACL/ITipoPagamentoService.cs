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
    public interface ITipoPagamentoService
    {
        Task<BaseListResponse<TipoPagamentoDTO>> GetAllAsync(TipoPagamentoListRequest filter, string language);
        Task<TipoPagamentoDTO> GetByIdAsync(int id, string language);
        Task<TipoPagamentoDTO> AddAsync(TipoPagamentoDTO dto, string language);
        Task<TipoPagamentoDTO> UpdateAsync(TipoPagamentoDTO dto, string language);
        Task DeleteAsync(int id);
    }
}