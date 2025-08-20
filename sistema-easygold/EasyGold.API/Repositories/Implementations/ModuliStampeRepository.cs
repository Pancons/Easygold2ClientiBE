using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class ModuliStampeRepository : IModuliStampeRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuliStampeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbModuliStampe>, int total)> GetAllAsync(ModuliStampeListRequest filter)
        {
            var query = _context.ModuliStampe.AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbModuliStampe> GetByIdAsync(int id)
        {
            return await _context.ModuliStampe.FindAsync(id);
        }

        public async Task AddAsync(DbModuliStampe entity)
        {
            await _context.ModuliStampe.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbModuliStampe entity)
        {
            _context.ModuliStampe.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ModuliStampe.FindAsync(id);
            if (entity != null)
            {
                _context.ModuliStampe.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}