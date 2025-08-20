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
    public interface ICreditCardRepository
    {
        Task<(IEnumerable<DbCreditCard>, int total)> GetAllAsync(CreditCardListRequest filter, string language);
        Task<DbCreditCard> GetByIdAsync(int id, string language);
        Task AddAsync(DbCreditCard entity, string language);
        Task UpdateAsync(DbCreditCard entity, string language);
        Task DeleteAsync(int id);
    }
}