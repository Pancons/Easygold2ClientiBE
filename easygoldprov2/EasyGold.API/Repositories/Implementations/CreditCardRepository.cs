using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCreditCard>> GetAllAsync()
        {
            return await _context.CreditCards.AsNoTracking().ToListAsync();
        }

        public async Task<DbCreditCard> GetByIdAsync(int id)
        {
            return await _context.CreditCards.AsNoTracking().FirstOrDefaultAsync(x => x.Crc_IDAuto == id);
        }

        public async Task AddAsync(DbCreditCard entity)
        {
            await _context.CreditCards.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCreditCard entity)
        {
            var existing = await _context.CreditCards.FindAsync(entity.Crc_IDAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CreditCards.FindAsync(id);
            if (entity != null)
            {
                _context.CreditCards.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}