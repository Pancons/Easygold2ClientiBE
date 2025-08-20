using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class IdiomiSceltiRepository : IIdiomiSceltiRepository
    {
        private readonly ApplicationDbContext _context;

        public IdiomiSceltiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbIdiomiScelti>, int total)> GetAllAsync(IdiomiSceltiListRequest filter)
        {
            var query = _context.IdiomiScelti.AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbIdiomiScelti> GetByIdAsync(int id)
        {
            return await _context.IdiomiScelti.FindAsync(id);
        }

        public async Task AddAsync(DbIdiomiScelti entity)
        {
            await _context.IdiomiScelti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbIdiomiScelti entity)
        {
            _context.IdiomiScelti.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.IdiomiScelti.FindAsync(id);
            if (entity != null)
            {
                _context.IdiomiScelti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}