using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class NazioneNegozioRepository : INazioneNegozioRepository
    {
        private readonly ApplicationDbContext _context;

        public NazioneNegozioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbNazioneNegozio> items, int total)> GetAllAsync(NazioneNegozioListRequest request)
        {
            var query = _context.NazioneNegozio.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbNazioneNegozio> GetByIdAsync(int id)
        {
            return await _context.NazioneNegozio.FindAsync(id);
        }

        public async Task AddAsync(DbNazioneNegozio entity)
        {
            await _context.NazioneNegozio.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbNazioneNegozio> UpdateAsync(DbNazioneNegozio entity)
        {
            _context.NazioneNegozio.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
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