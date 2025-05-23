using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class CauProgressiviLangRepository : ICauProgressiviLangRepository
    {
        private readonly ApplicationDbContext _context;

        public CauProgressiviLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCauProgressiviLang>> GetAllAsync()
        {
            return await _context.CauProgressiviLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbCauProgressiviLang> GetByIdAsync(int isonum, int id)
        {
            return await _context.CauProgressiviLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Prcid_ISONum == isonum && x.Prcid_ID == id);
        }

        public async Task AddAsync(DbCauProgressiviLang entity)
        {
            await _context.CauProgressiviLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCauProgressiviLang entity)
        {
            _context.CauProgressiviLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            var entity = await _context.CauProgressiviLang
                .FirstOrDefaultAsync(x => x.Prcid_ISONum == isonum && x.Prcid_ID == id);
            if (entity != null)
            {
                _context.CauProgressiviLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}