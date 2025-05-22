using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class NegoziAltroRepository : INegoziAltroRepository
    {
        private readonly ApplicationDbContext _context;

        public NegoziAltroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbNegoziAltro>> GetAllAsync()
        {
            return await _context.NegoziAltro.AsNoTracking().ToListAsync();
        }

        public async Task<DbNegoziAltro> GetByIdAsync(int id)
        {
            return await _context.NegoziAltro.AsNoTracking().FirstOrDefaultAsync(x => x.Nea_IDAuto == id);
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