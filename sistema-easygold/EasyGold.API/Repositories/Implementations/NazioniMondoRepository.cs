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
    public class NazioniMondoRepository : INazioniMondoRepository
    {
        private readonly ApplicationDbContext _context;

        public NazioniMondoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbNazioniMondo>, int total)> GetAllAsync(NazioniMondoListRequest filter, string language)
        {
            var query = _context.NazioniMondo
                .Include(n => n.NazioniMondoLang)
                .Where(n => n.NazioniMondoLang.Any(nl => nl.Nzmid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();
            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbNazioniMondo> GetByIdAsync(int id, string language)
        {
            return await _context.NazioniMondo
                .Include(n => n.NazioniMondoLang)
                .SingleOrDefaultAsync(n => n.Nzm_IDAuto == id && n.NazioniMondoLang.Any(nl => nl.Nzmid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbNazioniMondo entity, string language)
        {
            if (language == "39") // Se la lingua è italiano
            {
                await _context.NazioniMondo.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbNazioniMondo();
                await _context.NazioniMondo.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.NazioniMondoLang?.FirstOrDefault(nl => nl.Nzmid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Nzmid_ID = baseEntity.Nzm_IDAuto;
                    _context.NazioniMondoLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNazioniMondo entity, string language)
        {
            if (language == "39")
            {
                _context.NazioniMondo.Update(entity);
            }
            else
            {
                var lang = entity.NazioniMondoLang?.FirstOrDefault(nl => nl.Nzmid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.NazioniMondoLang
                        .FirstOrDefaultAsync(nl => nl.Nzmid_ID == entity.Nzm_IDAuto && nl.Nzmid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.Nzmid_Nazione = lang.Nzmid_Nazione;
                        existingLang.Nzmid_CapitaleIure = lang.Nzmid_CapitaleIure;
                        existingLang.Nzmid_CapitaleFatto = lang.Nzmid_CapitaleFatto;
                        existingLang.Nzmid_CapitaleAmm = lang.Nzmid_CapitaleAmm;
                        _context.NazioniMondoLang.Update(existingLang);
                    }
                    else
                    {
                        lang.Nzmid_ID = entity.Nzm_IDAuto;
                        _context.NazioniMondoLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.NazioniMondo.FindAsync(id);
            if (entity != null)
            {
                _context.NazioniMondo.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}