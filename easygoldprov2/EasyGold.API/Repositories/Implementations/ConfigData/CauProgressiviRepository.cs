using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class CauProgressiviRepository : ICauProgressiviRepository
    {
        private readonly ApplicationDbContext _context;

        public CauProgressiviRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCauProgressivi>> GetAllAsync()
        {
            return await _context.CauProgressivi.AsNoTracking().ToListAsync();
        }

        public async Task<DbCauProgressivi> GetByIdAsync(int id)
        {
            return await _context.CauProgressivi.AsNoTracking().FirstOrDefaultAsync(x => x.Cpr_IDAuto == id);
        }

        public async Task AddAsync(DbCauProgressivi entity)
        {
            await _context.CauProgressivi.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCauProgressivi entity)
        {
            _context.CauProgressivi.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CauProgressivi.FindAsync(id);
            if (entity != null)
            {
                _context.CauProgressivi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}