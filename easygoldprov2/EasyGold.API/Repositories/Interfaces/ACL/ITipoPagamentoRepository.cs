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
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ITipoPagamentoRepository
    {
        Task<(IEnumerable<DbTipoPagamento>, int total)> GetAllAsync(TipoPagamentoListRequest filter, string language);
        Task<DbTipoPagamento> GetByIdAsync(int id, string language);
        Task AddAsync(DbTipoPagamento entity, string language);
        Task UpdateAsync(DbTipoPagamento entity, string language);
        Task DeleteAsync(int id);
    }
}