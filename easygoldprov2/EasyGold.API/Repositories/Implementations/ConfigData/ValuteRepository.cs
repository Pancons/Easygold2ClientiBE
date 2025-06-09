using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class ValuteRepository : IValuteRepository
    {
        private readonly ApplicationDbContext _context;

        public ValuteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbValuta>> GetAllAsync()
        {
            return await _context.Valute.AsNoTracking().ToListAsync();
        }

        public async Task<DbValuta> GetByIdAsync(int id)
        {
            return await _context.Valute.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Val_IdAuto == id);
        }

        public async Task AddAsync(DbValuta entity)
        {
            await _context.Valute.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbValuta entity)
        {
            _context.Valute.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Valute.FindAsync(id);
            if (entity != null)
            {
                _context.Valute.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}