using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class AliquoteIVALangRepository : IAliquoteIVALangRepository
    {
        private readonly ApplicationDbContext _context;

        public AliquoteIVALangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbAliquoteIVALang>> GetAllAsync()
        {
            return await _context.AliquoteIVALang.AsNoTracking().ToListAsync();
        }

        public async Task<DbAliquoteIVALang> GetByIdAsync(int isonum, int id)
        {
            return await _context.AliquoteIVALang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Ivaid_ISONum == isonum && x.Ivaid_ID == id);
        }

        public async Task AddAsync(DbAliquoteIVALang entity)
        {
            await _context.AliquoteIVALang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbAliquoteIVALang entity)
        {
            _context.AliquoteIVALang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            var entity = await _context.AliquoteIVALang
                .FirstOrDefaultAsync(x => x.Ivaid_ISONum == isonum && x.Ivaid_ID == id);
            if (entity != null)
            {
                _context.AliquoteIVALang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}