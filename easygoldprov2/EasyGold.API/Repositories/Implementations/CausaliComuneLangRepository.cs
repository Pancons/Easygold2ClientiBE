using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class CausaliComuneLangRepository : ICausaliComuneLangRepository
    {
        private readonly ApplicationDbContext _context;

        public CausaliComuneLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCausaliComuneLang>> GetAllAsync()
        {
            return await _context.CausaliComuneLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbCausaliComuneLang> GetByIdAsync(int isonum, int id)
        {
            return await _context.CausaliComuneLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Cac_id_ISONum == isonum && x.Cac_id_ID == id);
        }

        public async Task AddAsync(DbCausaliComuneLang entity)
        {
            await _context.CausaliComuneLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCausaliComuneLang entity)
        {
            _context.CausaliComuneLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            var entity = await _context.CausaliComuneLang
                .FirstOrDefaultAsync(x => x.Cac_id_ISONum == isonum && x.Cac_id_ID == id);
            if (entity != null)
            {
                _context.CausaliComuneLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}