using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class OneriRivalutazioneRepository : IOneriRivalutazioneRepository
    {
        private readonly ApplicationDbContext _context;

        public OneriRivalutazioneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbOneriRivalutazione>> GetAllAsync()
        {
            return await _context.OneriRivalutazioni.AsNoTracking().ToListAsync();
        }

        public async Task<DbOneriRivalutazione> GetByIdAsync(int id)
        {
            return await _context.OneriRivalutazioni.AsNoTracking()
                                                    .FirstOrDefaultAsync(x => x.Onr_IdAuto == id);
        }

        public async Task AddAsync(DbOneriRivalutazione entity)
        {
            await _context.OneriRivalutazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbOneriRivalutazione entity)
        {
            _context.OneriRivalutazioni.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.OneriRivalutazioni.FindAsync(id);
            if (entity != null)
            {
                _context.OneriRivalutazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}