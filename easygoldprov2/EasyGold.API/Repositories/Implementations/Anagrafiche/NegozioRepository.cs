using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class NegozioRepository : INegozioRepository
    {
        private readonly ApplicationDbContext _context;

        public NegozioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbNegozi>, int)> GetAllAsync(NegozioListRequest filter)
        {
            var query = _context.Negozi.AsQueryable();

            int total = await query.CountAsync();
            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbNegozi> GetByIdAsync(int id)
        {
            return await _context.Negozi.FindAsync(id);
        }

        public async Task AddAsync(DbNegozi negozio)
        {
            await _context.Negozi.AddAsync(negozio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNegozi negozio)
        {
            _context.Negozi.Update(negozio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var negozio = await _context.Negozi.FindAsync(id);
            if (negozio != null)
            {
                _context.Negozi.Remove(negozio);
                await _context.SaveChangesAsync();
            }
        }
    }
}