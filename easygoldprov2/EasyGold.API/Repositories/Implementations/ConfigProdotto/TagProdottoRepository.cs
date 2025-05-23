using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations.ConfigProdotto
{
    public class TagProdottoRepository : ITagProdottoRepository
    {
        private readonly ApplicationDbContext _context;

        public TagProdottoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbTagProdotto>> GetAllAsync()
        {
            return await _context.TagProdotti.AsNoTracking().ToListAsync();
        }

        public async Task<DbTagProdotto> GetByIdAsync(int id)
        {
            return await _context.TagProdotti.AsNoTracking()
                                             .FirstOrDefaultAsync(x => x.Etp_IdAuto == id);
        }

        public async Task AddAsync(DbTagProdotto entity)
        {
            await _context.TagProdotti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTagProdotto entity)
        {
            _context.TagProdotti.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TagProdotti.FindAsync(id);
            if (entity != null)
            {
                _context.TagProdotti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}