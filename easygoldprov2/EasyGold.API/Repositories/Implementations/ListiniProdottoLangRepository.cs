using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class ListiniProdottoLangRepository : IListiniProdottoLangRepository
    {
        private readonly ApplicationDbContext _context;

        public ListiniProdottoLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbListiniProdottoLang>> GetAllAsync()
        {
            return await _context.ListiniProdottoLang.AsNoTracking().ToListAsync();
        }

        public async Task<DbListiniProdottoLang> GetByIdAsync(int lisidISONum, int lisidID)
        {
            return await _context.ListiniProdottoLang
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Lisid_ISONum == lisidISONum && x.Lisid_ID == lisidID);
        }

        public async Task AddAsync(DbListiniProdottoLang entity)
        {
            await _context.ListiniProdottoLang.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbListiniProdottoLang entity)
        {
            _context.ListiniProdottoLang.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int lisidISONum, int lisidID)
        {
            var entity = await _context.ListiniProdottoLang
                .FirstOrDefaultAsync(x => x.Lisid_ISONum == lisidISONum && x.Lisid_ID == lisidID);
            if (entity != null)
            {
                _context.ListiniProdottoLang.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}