using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class CausaliClienteLangRepository : ICausaliClienteLangRepository
    {
        private readonly ApplicationDbContext _context;

        public CausaliClienteLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCausaliClienteLang>> GetAllAsync()
        {
            return await _context.CausaliClienteLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbCausaliClienteLang> GetByIdAsync(int isonum, int id)
        {
            return await _context.CausaliClienteLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Cal_id_ISONum == isonum && x.Cal_id_ID == id);
        }

        public async Task AddAsync(DbCausaliClienteLang entity)
        {
            await _context.CausaliClienteLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCausaliClienteLang entity)
        {
            _context.CausaliClienteLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            var entity = await _context.CausaliClienteLang
                .FirstOrDefaultAsync(x => x.Cal_id_ISONum == isonum && x.Cal_id_ID == id);
            if (entity != null)
            {
                _context.CausaliClienteLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class CausaliClienteLangRepository : ICausaliClienteLangRepository
    {
        private readonly ApplicationDbContext _context;

        public CausaliClienteLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCausaliClienteLang>> GetAllAsync()
        {
            return await _context.CausaliClienteLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbCausaliClienteLang> GetByIdAsync(int isonum, int id)
        {
            return await _context.CausaliClienteLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Cal_id_ISONum == isonum && x.Cal_id_ID == id);
        }

        public async Task AddAsync(DbCausaliClienteLang entity)
        {
            await _context.CausaliClienteLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCausaliClienteLang entity)
        {
            _context.CausaliClienteLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int isonum, int id)
        {
            var entity = await _context.CausaliClienteLang
                .FirstOrDefaultAsync(x => x.Cal_id_ISONum == isonum && x.Cal_id_ID == id);
            if (entity != null)
            {
                _context.CausaliClienteLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
