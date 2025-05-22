using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class ListiniProdottoRepository : IListiniProdottoRepository
    {
        private readonly ApplicationDbContext _context;

        public ListiniProdottoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbListiniProdotto>> GetAllAsync()
        {
            return await _context.ListiniProdotto.AsNoTracking().ToListAsync();
        }

        public async Task<DbListiniProdotto> GetByIdAsync(int id)
        {
            return await _context.ListiniProdotto.AsNoTracking().FirstOrDefaultAsync(x => x.Lis_IDAuto == id);
        }

        public async Task AddAsync(DbListiniProdotto entity)
        {
            await _context.ListiniProdotto.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbListiniProdotto entity)
        {
            _context.ListiniProdotto.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ListiniProdotto.FindAsync(id);
            if (entity != null)
            {
                _context.ListiniProdotto.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}