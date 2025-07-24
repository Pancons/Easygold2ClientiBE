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
    public class PwUtentiRepository : IPwUtentiRepository
    {
        private readonly ApplicationDbContext _context;

        public PwUtentiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbPwUtenti>, int total)> GetAllAsync(PwUtentiListRequest filter)
        {
            var query = _context.PwUtenti.AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbPwUtenti> GetByIdAsync(int id)
        {
            return await _context.PwUtenti.FindAsync(id);
        }

        public async Task AddAsync(DbPwUtenti entity)
        {
            await _context.PwUtenti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbPwUtenti entity)
        {
            _context.PwUtenti.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PwUtenti.FindAsync(id);
            if (entity != null)
            {
                _context.PwUtenti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}