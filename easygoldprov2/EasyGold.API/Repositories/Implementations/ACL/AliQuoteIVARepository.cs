using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class AliQuoteIVARepository : IAliQuoteIVARepository
    {
        private readonly ApplicationDbContext _context;

        public AliQuoteIVARepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbAliQuoteIVA>, int total)> GetAllAsync(AliQuoteIVAListRequest filter, string language)
        {
            var query = _context.AliQuoteIVA
                .Include(a => a.AliQuoteIVALang)
                .Where(a => a.AliQuoteIVALang.Any(al => al.Ivaid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbAliQuoteIVA> GetByIdAsync(int id, string language)
        {
            return await _context.AliQuoteIVA
                .Include(a => a.AliQuoteIVALang)
                .SingleOrDefaultAsync(a => a.Iva_IDAuto == id && a.AliQuoteIVALang.Any(al => al.Ivaid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbAliQuoteIVA entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiungere direttamente alla tabella principale
                await _context.AliQuoteIVA.AddAsync(entity);
            }
            else
            {
                // Non italiano: aggiungere alla tabella delle traduzioni
                var baseEntity = new DbAliQuoteIVA();
                await _context.AliQuoteIVA.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.AliQuoteIVALang?.FirstOrDefault(al => al.Ivaid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Ivaid_ID = baseEntity.Iva_IDAuto;
                    _context.AliQuoteIVALang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbAliQuoteIVA entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiornare la tabella principale
                _context.AliQuoteIVA.Update(entity);
            }
            else
            {
                var lang = entity.AliQuoteIVALang?.FirstOrDefault(al => al.Ivaid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.AliQuoteIVALang
                        .FirstOrDefaultAsync(al =>
                            al.Ivaid_ID == entity.Iva_IDAuto &&
                            al.Ivaid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna
                        existingLang.Ivaid_Descrizione = lang.Ivaid_Descrizione;
                        _context.AliQuoteIVALang.Update(existingLang);
                    }
                    else
                    {
                        // Nuova traduzione
                        lang.Ivaid_ID = entity.Iva_IDAuto;
                        _context.AliQuoteIVALang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.AliQuoteIVA.FindAsync(id);
            if (entity != null)
            {
                _context.AliQuoteIVA.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}