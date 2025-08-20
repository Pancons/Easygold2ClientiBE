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
    public class CauProgressiviRepository : ICauProgressiviRepository
    {
        private readonly ApplicationDbContext _context;

        public CauProgressiviRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCauProgressivi>, int total)> GetAllAsync(CauProgressiviListRequest filter, string language)
        {
            var query = _context.CauProgressivi
                .Include(cp => cp.CauProgressiviLang)
                .Where(cp => cp.CauProgressiviLang.Any(cpl => cpl.Prcid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();
            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbCauProgressivi> GetByIdAsync(int id, string language)
        {
            return await _context.CauProgressivi
                .Include(cp => cp.CauProgressiviLang)
                .SingleOrDefaultAsync(cp => cp.Cpr_IDAuto == id && cp.CauProgressiviLang.Any(cpl => cpl.Prcid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbCauProgressivi entity, string language)
        {
            if (language == "39") // Se la lingua è italiano
            {
                await _context.CauProgressivi.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbCauProgressivi();
                await _context.CauProgressivi.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.CauProgressiviLang?.FirstOrDefault(cpl => cpl.Prcid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Prcid_ID = baseEntity.Cpr_IDAuto;
                    _context.CauProgressiviLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCauProgressivi entity, string language)
        {
            if (language == "39")
            {
                _context.CauProgressivi.Update(entity);
            }
            else
            {
                var lang = entity.CauProgressiviLang?.FirstOrDefault(cpl => cpl.Prcid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.CauProgressiviLang
                        .FirstOrDefaultAsync(cpl => cpl.Prcid_ID == entity.Cpr_IDAuto && cpl.Prcid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.Prcid_Descrizione = lang.Prcid_Descrizione;
                        _context.CauProgressiviLang.Update(existingLang);
                    }
                    else
                    {
                        lang.Prcid_ID = entity.Cpr_IDAuto;
                        _context.CauProgressiviLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CauProgressivi.FindAsync(id);
            if (entity != null)
            {
                _context.CauProgressivi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}