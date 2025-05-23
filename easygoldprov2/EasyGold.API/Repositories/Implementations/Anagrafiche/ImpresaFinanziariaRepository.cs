using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class ImpresaFinanziariaRepository : IImpresaFinanziariaRepository
    {
        private readonly ApplicationDbContext _context;

        public ImpresaFinanziariaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbImpresaFinanziaria>> GetAllAsync()
        {
            return await _context.ImpreseFinanziarie.AsNoTracking().ToListAsync();
        }

        public async Task<DbImpresaFinanziaria> GetByIdAsync(int id)
        {
            return await _context.ImpreseFinanziarie.AsNoTracking()
                                                     .FirstOrDefaultAsync(x => x.Imf_IdAuto == id);
        }

        public async Task AddAsync(DbImpresaFinanziaria entity)
        {
            await _context.ImpreseFinanziarie.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbImpresaFinanziaria entity)
        {
            _context.ImpreseFinanziarie.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ImpreseFinanziarie.FindAsync(id);
            if (entity != null)
            {
                _context.ImpreseFinanziarie.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}