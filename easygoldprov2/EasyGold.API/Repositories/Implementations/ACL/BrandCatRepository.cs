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
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class BrandCatRepository : IBrandCatRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandCatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbBrandCat> items, int total)> GetAllAsync(BrandCatListRequest request)
        {
            var query = _context.BrandCats.AsQueryable();

            // Applica filtri se necessario
            // Esempio: query = query.Where(x => x.SomeProperty == request.SomeProperty);

            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbBrandCat> GetByIdAsync(int id)
        {
            return await _context.BrandCats.FindAsync(id);
        }

        public async Task AddAsync(DbBrandCat entity)
        {
            await _context.BrandCats.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbBrandCat> UpdateAsync(DbBrandCat entity)
        {
            _context.BrandCats.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.BrandCats.FindAsync(id);
            if (entity != null)
            {
                _context.BrandCats.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}