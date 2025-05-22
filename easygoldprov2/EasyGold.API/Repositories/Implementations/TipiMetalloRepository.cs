using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class TipiMetalloRepository : ITipiMetalloRepository
    {
        private readonly ApplicationDbContext _context;

        public TipiMetalloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbTipiMetallo>> GetAllAsync()
        {
            return await _context.TipiMetallo.AsNoTracking().ToListAsync();
        }

        public async Task<DbTipiMetallo> GetByIdAsync(int id)
        {
            return await _context.TipiMetallo.AsNoTracking().FirstOrDefaultAsync(x => x.Tim_IDAuto == id);
        }

        public async Task AddAsync(DbTipiMetallo entity)
        {
            await _context.TipiMetallo.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTipiMetallo entity)
        {
            _context.TipiMetallo.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipiMetallo.FindAsync(id);
            if (entity != null)
            {
                _context.TipiMetallo.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}