using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class IndirizziLangRepository : IIndirizziLangRepository
    {
        private readonly ApplicationDbContext _context;

        public IndirizziLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbIndirizziLang>> GetAllAsync()
        {
            return await _context.IndirizziLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbIndirizziLang> GetByIdAsync(int stridISONum, int stridID)
        {
            return await _context.IndirizziLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StridISONum == stridISONum && x.StridID == stridID);
        }

        public async Task AddAsync(DbIndirizziLang entity)
        {
            await _context.IndirizziLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbIndirizziLang entity)
        {
            _context.IndirizziLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int stridISONum, int stridID)
        {
            var entity = await _context.IndirizziLang
                .FirstOrDefaultAsync(x => x.StridISONum == stridISONum && x.StridID == stridID);
            if (entity != null)
            {
                _context.IndirizziLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}