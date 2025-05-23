using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class UtentiRepository : IUtentiRepository
    {
        private readonly ApplicationDbContext _context;

        public UtentiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbUtenti>> GetAllAsync()
        {
            return await _context.Utenti.AsNoTracking().ToListAsync();
        }

        public async Task<DbUtenti> GetByIdAsync(int id)
        {
            return await _context.Utenti.AsNoTracking().FirstOrDefaultAsync(x => x.Ute_IDAuto == id);
        }

        public async Task AddAsync(DbUtenti entity)
        {
            await _context.Utenti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbUtenti entity)
        {
            _context.Utenti.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Utenti.FindAsync(id);
            if (entity != null)
            {
                _context.Utenti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}