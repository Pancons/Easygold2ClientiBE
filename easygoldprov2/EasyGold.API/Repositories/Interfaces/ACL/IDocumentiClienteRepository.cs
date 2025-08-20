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
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;


namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IDocumentiClienteRepository
    {
        Task<(IEnumerable<DbDocumentiCliente> items, int total)> GetAllAsync(DocumentiClienteListRequest request);
        Task<DbDocumentiCliente> GetByIdAsync(int id);
        Task AddAsync(DbDocumentiCliente dto);
        Task<DbDocumentiCliente> UpdateAsync(DbDocumentiCliente dto);
        Task DeleteAsync(int id);
    }
}