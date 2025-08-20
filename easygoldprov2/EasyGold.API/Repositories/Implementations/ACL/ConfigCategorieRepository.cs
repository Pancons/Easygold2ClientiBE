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
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class ConfigCategorieRepository : IConfigCategorieRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigCategorieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbConfigCategorie>items, int total)> GetAllAsync(ConfigCategorieListRequest request)
        {
            var query = _context.ConfigCategorie.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbConfigCategorie> GetByIdAsync(int id)
        {
            return await _context.ConfigCategorie.FindAsync(id);
        }

        public async Task AddAsync(DbConfigCategorie entity)
        {
            await _context.ConfigCategorie.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbConfigCategorie entity)
        {
            _context.ConfigCategorie.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ConfigCategorie.FindAsync(id);
            if (entity != null)
            {
                _context.ConfigCategorie.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}