using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations
{
    public class TipoSKURepository : ITipoSKURepository
    {
        private readonly ApplicationDbContext _context;

        public TipoSKURepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbTipoSKU>> GetAllAsync()
        {
            return await _context.TipoSKUs.AsNoTracking().ToListAsync();
        }

        public async Task<DbTipoSKU> GetByIdAsync(int id)
        {
            return await _context.TipoSKUs.AsNoTracking()
                                          .FirstOrDefaultAsync(x => x.Sku_IdAuto == id);
        }

        public async Task AddAsync(DbTipoSKU entity)
        {
            await _context.TipoSKUs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTipoSKU entity)
        {
            _context.TipoSKUs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipoSKUs.FindAsync(id);
            if (entity != null)
            {
                _context.TipoSKUs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}