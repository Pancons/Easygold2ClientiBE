using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities.RegIVA;
using EasyGold.API.Repositories.Interfaces.Contabilita;

namespace EasyGold.API.Repositories.Implementations.Contabilita
{
    public class RegistroIVARepository : IRegistroIVARepository
    {
        private readonly ApplicationDbContext _context;

        public RegistroIVARepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbRegistroIVA>> GetAllAsync()
        {
            return await _context.RegistriIVA.AsNoTracking().ToListAsync();
        }

        public async Task<DbRegistroIVA> GetByIdAsync(int id)
        {
            return await _context.RegistriIVA.AsNoTracking().FirstOrDefaultAsync(r => r.RowIdAuto == id);
        }

        public async Task AddAsync(DbRegistroIVA registro)
        {
            await _context.RegistriIVA.AddAsync(registro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbRegistroIVA registro)
        {
            var existing = await _context.RegistriIVA.FindAsync(registro.RowIdAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(registro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var registro = await _context.RegistriIVA.FindAsync(id);
            if (registro != null)
            {
                _context.RegistriIVA.Remove(registro);
                await _context.SaveChangesAsync();
            }
        }
    }
}