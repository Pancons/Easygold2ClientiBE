using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class AliquoteIVARepository : IAliquoteIVARepository
    {
        private readonly ApplicationDbContext _context;

        public AliquoteIVARepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbAliquoteIVA>> GetAllAsync()
        {
            return await _context.AliquoteIVA.AsNoTracking().ToListAsync();
        }

        public async Task<DbAliquoteIVA> GetByIdAsync(int id)
        {
            return await _context.AliquoteIVA.AsNoTracking().FirstOrDefaultAsync(x => x.Iva_IDAuto == id);
        }

        public async Task AddAsync(DbAliquoteIVA entity)
        {
            await _context.AliquoteIVA.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbAliquoteIVA entity)
        {
            _context.AliquoteIVA.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.AliquoteIVA.FindAsync(id);
            if (entity != null)
            {
                _context.AliquoteIVA.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}