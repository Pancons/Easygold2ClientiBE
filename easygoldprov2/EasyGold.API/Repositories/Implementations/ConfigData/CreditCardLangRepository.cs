using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Infrastructure;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class CreditCardLangRepository : ICreditCardLangRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditCardLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCreditCardLang>> GetAllAsync()
        {
            return await _context.CreditCardLangs.AsNoTracking().ToListAsync();
        }

        public async Task<DbCreditCardLang> GetByIdAsync(int isoNum, int id)
        {
            return await _context.CreditCardLangs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Crcid_ISONum == isoNum && x.Crcid_ID == id);
        }

        public async Task AddAsync(DbCreditCardLang entity)
        {
            await _context.CreditCardLangs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCreditCardLang entity)
        {
            var existing = await _context.CreditCardLangs
                .FirstOrDefaultAsync(x => x.Crcid_ISONum == entity.Crcid_ISONum && x.Crcid_ID == entity.Crcid_ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int isoNum, int id)
        {
            var entity = await _context.CreditCardLangs
                .FirstOrDefaultAsync(x => x.Crcid_ISONum == isoNum && x.Crcid_ID == id);
            if (entity != null)
            {
                _context.CreditCardLangs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}