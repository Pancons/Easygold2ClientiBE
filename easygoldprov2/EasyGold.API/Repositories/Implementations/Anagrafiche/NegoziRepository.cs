using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class NegoziRepository : INegoziRepository
    {
        private readonly ApplicationDbContext _context;

        public NegoziRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbNegozi>> GetAllAsync()
        {
            return await _context.Negozi.AsNoTracking().ToListAsync();
        }

        public async Task<DbNegozi> GetByIdAsync(int id)
        {
            return await _context.Negozi.AsNoTracking().FirstOrDefaultAsync(x => x.Neg_IDAuto == id);
        }

        public async Task AddAsync(DbNegozi entity)
        {
            await _context.Negozi.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNegozi entity)
        {
            _context.Negozi.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Negozi.FindAsync(id);
            if (entity != null)
            {
                _context.Negozi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}