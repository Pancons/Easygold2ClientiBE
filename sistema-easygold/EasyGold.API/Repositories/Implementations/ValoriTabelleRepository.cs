using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Utenti;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace EasyGold.API.Repositories.Implementations
{


    public class ValoriTabelleRepository : IValoriTabelleRepository
    {
        private readonly ApplicationDbContext _context;

        public ValoriTabelleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbValoriTabelle>> FindByItemTypeAsync(string itemType)
        {
            return await _context.ValoriTabelle
                .Where(x => x.lst_itemType == itemType && x.rowDeletedAt == null)
                .ToListAsync();
        }

        public async Task<DbValoriTabelle> GetByIdAsync(int id)
        {
            return await _context.ValoriTabelle
                .FirstOrDefaultAsync(x => x.rowId == id && x.rowDeletedAt == null);
        }

        public async Task InsertAsync(DbValoriTabelle entity)
        {
            entity.rowCreatedAt = DateTime.UtcNow;
            entity.rowUpdatedAt = DateTime.UtcNow;
            await _context.ValoriTabelle.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbValoriTabelle entity)
        {
            entity.rowUpdatedAt = DateTime.UtcNow;
            _context.ValoriTabelle.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}