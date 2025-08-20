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
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class CausaliComuneRepository : ICausaliComuneRepository
    {
        private readonly ApplicationDbContext _context;

        public CausaliComuneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCausaliComune>, int total)> GetAllAsync(CausaliComuneListRequest filter, string language)
        {
            var query = _context.CausaliComune
                .Include(c => c.CausaliComuneLang)
                .Where(c => c.CausaliComuneLang.Any(cl => cl.Cac_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();
            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbCausaliComune> GetByIdAsync(int id, string language)
        {
            return await _context.CausaliComune
                .Include(c => c.CausaliComuneLang)
                .SingleOrDefaultAsync(c => c.Cac_IDAuto == id && c.CausaliComuneLang.Any(cl => cl.Cac_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbCausaliComune entity, string language)
        {
            if (language == "39") // Se la lingua è italiano
            {
                await _context.CausaliComune.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbCausaliComune();
                await _context.CausaliComune.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.CausaliComuneLang?.FirstOrDefault(cl => cl.Cac_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Cac_ID = baseEntity.Cac_IDAuto;
                    _context.CausaliComuneLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCausaliComune entity, string language)
        {
            if (language == "39")
            {
                _context.CausaliComune.Update(entity);
            }
            else
            {
                var lang = entity.CausaliComuneLang?.FirstOrDefault(cl => cl.Cac_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.CausaliComuneLang
                        .FirstOrDefaultAsync(cl => cl.Cac_ID == entity.Cac_IDAuto && cl.Cac_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.Cac_Descrizione = lang.Cac_Descrizione;
                        _context.CausaliComuneLang.Update(existingLang);
                    }
                    else
                    {
                        lang.Cac_ID = entity.Cac_IDAuto;
                        _context.CausaliComuneLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CausaliComune.FindAsync(id);
            if (entity != null)
            {
                _context.CausaliComune.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}