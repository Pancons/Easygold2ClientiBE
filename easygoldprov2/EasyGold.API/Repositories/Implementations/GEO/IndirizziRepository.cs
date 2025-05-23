using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.API.Repositories.Interfaces.GEO;

namespace EasyGold.API.Repositories.Implementations.GEO
{
    public class IndirizziRepository : IIndirizziRepository
    {
        private readonly ApplicationDbContext _context;

        public IndirizziRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbIndirizzi>> GetAllAsync()
        {
            return await _context.Indirizzi.AsNoTracking().ToListAsync();
        }

        public async Task<DbIndirizzi> GetByIdAsync(int id)
        {
            return await _context.Indirizzi.AsNoTracking().FirstOrDefaultAsync(x => x.StrIdAuto == id);
        }

        public async Task AddAsync(DbIndirizzi entity)
        {
            await _context.Indirizzi.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbIndirizzi entity)
        {
            _context.Indirizzi.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Indirizzi.FindAsync(id);
            if (entity != null)
            {
                _context.Indirizzi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}