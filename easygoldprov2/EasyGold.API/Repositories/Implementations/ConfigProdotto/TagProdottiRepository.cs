using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Infrastructure;
using EasyGold.API.Repositories.Interfaces.Prodotti;

namespace EasyGold.API.Repositories.Implementations.ConfigProdotto
{
    public class TagProdottiRepository : ITagProdottiRepository
    {
        private readonly ApplicationDbContext _context;

        public TagProdottiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbTagProdotti>> GetAllAsync()
        {
            return await _context.TagProdotti.AsNoTracking().ToListAsync();
        }

        public async Task<DbTagProdotti> GetByIdAsync(int id)
        {
            return await _context.TagProdotti.AsNoTracking().FirstOrDefaultAsync(x => x.Etp_IDAuto == id);
        }

        public async Task AddAsync(DbTagProdotti entity)
        {
            await _context.TagProdotti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTagProdotti entity)
        {
            var existing = await _context.TagProdotti.FindAsync(entity.Etp_IDAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
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