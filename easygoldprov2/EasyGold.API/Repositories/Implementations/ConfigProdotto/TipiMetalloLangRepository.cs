using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.ConfigProdotto;

namespace EasyGold.API.Repositories.Implementations.ConfigProdotto
{
    public class TipiMetalloLangRepository : ITipiMetalloLangRepository
    {
        private readonly ApplicationDbContext _context;

        public TipiMetalloLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbTipiMetalloLang>> GetAllAsync()
        {
            return await _context.TipiMetalloLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbTipiMetalloLang> GetByIdAsync(int timidISONum, int timidID)
        {
            return await _context.TipiMetalloLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Timid_ISONum == timidISONum && x.Timid_ID == timidID);
        }

        public async Task AddAsync(DbTipiMetalloLang entity)
        {
            await _context.TipiMetalloLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTipiMetalloLang entity)
        {
            _context.TipiMetalloLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int timidISONum, int timidID)
        {
            var entity = await _context.TipiMetalloLang
                .FirstOrDefaultAsync(x => x.Timid_ISONum == timidISONum && x.Timid_ID == timidID);
            if (entity != null)
            {
                _context.TipiMetalloLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}