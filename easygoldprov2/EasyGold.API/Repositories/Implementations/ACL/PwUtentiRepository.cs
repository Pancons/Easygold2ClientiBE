using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class PwUtentiRepository : IPwUtentiRepository
    {
        private readonly ApplicationDbContext _context;

        public PwUtentiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbPwUtenti>> GetAllAsync()
        {
            return await _context.PwUtenti.AsNoTracking().ToListAsync();
        }

        public async Task<DbPwUtenti> GetByIdAsync(int id)
        {
            return await _context.PwUtenti.AsNoTracking().FirstOrDefaultAsync(x => x.Utp_IDAuto == id);
        }

        public async Task AddAsync(DbPwUtenti entity)
        {
            await _context.PwUtenti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbPwUtenti entity)
        {
            _context.PwUtenti.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PwUtenti.FindAsync(id);
            if (entity != null)
            {
                _context.PwUtenti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}