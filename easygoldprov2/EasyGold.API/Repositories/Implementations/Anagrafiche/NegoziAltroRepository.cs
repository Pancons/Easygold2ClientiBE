using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class NegoziAltroRepository : INegoziAltroRepository
    {
        private readonly ApplicationDbContext _context;

        public NegoziAltroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbNegoziAltro>, int)> GetAllAsync(NegozioAltroListRequest filter)
        {
            var query = _context.NegoziAltro.AsQueryable();

            int total = await query.CountAsync();
            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbNegoziAltro> GetByIdAsync(int id)
        {
            return await _context.NegoziAltro.FindAsync(id);
        }

        public async Task AddAsync(DbNegoziAltro entity)
        {
            await _context.NegoziAltro.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNegoziAltro entity)
        {
            _context.NegoziAltro.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.NegoziAltro.FindAsync(id);
            if (entity != null)
            {
                _context.NegoziAltro.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}