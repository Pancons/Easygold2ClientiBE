using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class LocalitaRepository : ILocalitaRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalitaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbLocalita>, int total)> GetAllAsync(LocalitaListRequest filter, string language)
        {
            var query = _context.Localita
                .Include(l => l.LocalitaLang)
                .Where(l => l.LocalitaLang.Any(ll => ll.Strid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbLocalita> GetByIdAsync(int id, string language)
        {
            return await _context.Localita
                .Include(l => l.LocalitaLang)
                .SingleOrDefaultAsync(l => l.Str_IDAuto == id && l.LocalitaLang.Any(ll => ll.Strid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbLocalita entity, string language)
        {
            if (language == "39")
            {
                await _context.Localita.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbLocalita();
                await _context.Localita.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.LocalitaLang?.FirstOrDefault(ll => ll.Strid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Strid_ID = baseEntity.Str_IDAuto;
                    _context.LocalitaLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbLocalita entity, string language)
        {
            if (language == "39")
            {
                _context.Localita.Update(entity);
            }
            else
            {
                var lang = entity.LocalitaLang?.FirstOrDefault(ll => ll.Strid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.LocalitaLang
                        .FirstOrDefaultAsync(ll =>
                            ll.Strid_ID == entity.Str_IDAuto &&
                            ll.Strid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.Strid_Descrizione = lang.Strid_Descrizione;
                        _context.LocalitaLang.Update(existingLang);
                    }
                    else
                    {
                        lang.Strid_ID = entity.Str_IDAuto;
                        _context.LocalitaLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Localita.FindAsync(id);
            if (entity != null)
            {
                _context.Localita.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}