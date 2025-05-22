using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations
{
    public class CodPagamentoRepository : ICodPagamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public CodPagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCondizionePagamento>> GetAllAsync()
        {
            return await _context.CondizioniPagamento.AsNoTracking().ToListAsync();
        }

        public async Task<DbCondizionePagamento> GetByIdAsync(int id)
        {
            return await _context.CondizioniPagamento.AsNoTracking()
                                                     .FirstOrDefaultAsync(x => x.Cpa_IdAuto == id);
        }

        public async Task AddAsync(DbCondizionePagamento entity)
        {
            await _context.CondizioniPagamento.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCondizionePagamento entity)
        {
            _context.CondizioniPagamento.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CondizioniPagamento.FindAsync(id);
            if (entity != null)
            {
                _context.CondizioniPagamento.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}