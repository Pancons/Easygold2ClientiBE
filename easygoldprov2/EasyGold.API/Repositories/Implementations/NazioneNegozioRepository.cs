using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class NazioneNegozioRepository : INazioneNegozioRepository
    {
        private readonly ApplicationDbContext _context;

        public NazioneNegozioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbNazioneNegozio>> GetAllAsync()
        {
            return await _context.NazioneNegozio.AsNoTracking().ToListAsync();
        }

        public async Task<DbNazioneNegozio> GetByIdAsync(int id)
        {
            return await _context.NazioneNegozio.AsNoTracking().FirstOrDefaultAsync(x => x.Nne_IDAuto == id);
        }

        public async Task AddAsync(DbNazioneNegozio entity)
        {
            await _context.NazioneNegozio.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNazioneNegozio entity)
        {
            _context.NazioneNegozio.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.NazioneNegozio.FindAsync(id);
            if (entity != null)
            {
                _context.NazioneNegozio.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}