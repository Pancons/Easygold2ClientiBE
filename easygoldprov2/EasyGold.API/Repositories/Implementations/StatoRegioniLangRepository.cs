using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class StatoRegioniLangRepository : IStatoRegioniLangRepository
    {
        private readonly ApplicationDbContext _context;

        public StatoRegioniLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbStatoRegioniLang>> GetAllAsync()
        {
            return await _context.StatoRegioniLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbStatoRegioniLang> GetByIdAsync(int stridISONum, int stridID)
        {
            return await _context.StatoRegioniLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StridISONum == stridISONum && x.StridID == stridID);
        }

        public async Task AddAsync(DbStatoRegioniLang entity)
        {
            await _context.StatoRegioniLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbStatoRegioniLang entity)
        {
            _context.StatoRegioniLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int stridISONum, int stridID)
        {
            var entity = await _context.StatoRegioniLang
                .FirstOrDefaultAsync(x => x.StridISONum == stridISONum && x.StridID == stridID);
            if (entity != null)
            {
                _context.StatoRegioniLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}