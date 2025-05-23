using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class TipoPagamentoRepository : ITipoPagamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoPagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbTipoPagamento>> GetAllAsync()
        {
            return await _context.TipoPagamenti.AsNoTracking().ToListAsync();
        }

        public async Task<DbTipoPagamento> GetByIdAsync(int id)
        {
            return await _context.TipoPagamenti.AsNoTracking()
                                               .FirstOrDefaultAsync(x => x.Tip_IdAuto == id);
        }

        public async Task AddAsync(DbTipoPagamento entity)
        {
            await _context.TipoPagamenti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTipoPagamento entity)
        {
            _context.TipoPagamenti.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipoPagamenti.FindAsync(id);
            if (entity != null)
            {
                _context.TipoPagamenti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}