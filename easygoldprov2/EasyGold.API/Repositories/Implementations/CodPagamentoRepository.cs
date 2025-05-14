using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class CodPagamentoRepository : ICodPagamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public CodPagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCodPagamento>> GetAllAsync()
        {
            return await _context.CodPagamenti.AsNoTracking().ToListAsync();
        }

        public async Task<DbCodPagamento> GetByIdAsync(int id)
        {
            return await _context.CodPagamenti.AsNoTracking().FirstOrDefaultAsync(x => x.Cpa_IDAuto == id);
        }

        public async Task AddAsync(DbCodPagamento entity)
        {
            await _context.CodPagamenti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCodPagamento entity)
        {
            var existing = await _context.CodPagamenti.FindAsync(entity.Cpa_IDAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CodPagamenti.FindAsync(id);
            if (entity != null)
            {
                _context.CodPagamenti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}