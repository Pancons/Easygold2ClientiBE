using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;

namespace EasyGold.API.Repositories.Implementations.ConfigProdotto
{
    public class PietrePrezioseRepository : IPietrePrezioseRepository
    {
        private readonly ApplicationDbContext _context;

        public PietrePrezioseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbPietraPreziosa>> GetAllAsync()
        {
            return await _context.PietrePreziose.AsNoTracking().ToListAsync();
        }

        public async Task<DbPietraPreziosa> GetByIdAsync(int id)
        {
            return await _context.PietrePreziose.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Ppz_IdAuto == id);
        }

        public async Task AddAsync(DbPietraPreziosa entity)
        {
            await _context.PietrePreziose.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbPietraPreziosa entity)
        {
            _context.PietrePreziose.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PietrePreziose.FindAsync(id);
            if (entity != null)
            {
                _context.PietrePreziose.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}