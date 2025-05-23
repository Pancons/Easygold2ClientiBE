using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class NegozioRepository : INegozioRepository
    {
        private readonly ApplicationDbContext _context;

        public NegozioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbNegozi>> GetAllAsync()
        {
            return await _context.Negozi.ToListAsync();
        }

        public async Task<DbNegozi> GetByIdAsync(int id)
        {
            return await _context.Negozi.FindAsync(id);
        }

        public async Task AddAsync(DbNegozi negozio)
        {
            await _context.Negozi.AddAsync(negozio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNegozi negozio)
        {
            var negozioEsistente = await _context.Negozi.FindAsync(negozio.Neg_id);
            if (negozioEsistente != null)
            {
                _context.Entry(negozioEsistente).CurrentValues.SetValues(negozio);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var negozio = await GetByIdAsync(id);
            if (negozio != null)
            {
                _context.Negozi.Remove(negozio);
                await _context.SaveChangesAsync();
            }
        }

    }
}
