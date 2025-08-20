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
    public class IndirizziRepository : IIndirizziRepository
    {
        private readonly ApplicationDbContext _context;

        public IndirizziRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbIndirizzi>, int total)> GetAllAsync(IndirizziListRequest filter, string language)
        {
            var query = _context.Indirizzi
                .Include(i => i.IndirizziLang)
                .Where(i => i.IndirizziLang.Any(il => il.Strid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbIndirizzi> GetByIdAsync(int id, string language)
        {
            return await _context.Indirizzi
                .Include(i => i.IndirizziLang)
                .SingleOrDefaultAsync(i => i.Str_IDAuto == id && i.IndirizziLang.Any(il => il.Strid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbIndirizzi entity, string language)
        {
            if (language == "39")
            {
                // Italiano: scriviamo nella tabella principale
                await _context.Indirizzi.AddAsync(entity);
            }
            else
            {
                // Non italiano: creiamo l'entità base per ottenere l'ID
                var baseEntity = new DbIndirizzi();
                await _context.Indirizzi.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.IndirizziLang?.FirstOrDefault(il => il.Strid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Strid_ID = baseEntity.Str_IDAuto;
                    _context.IndirizziLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbIndirizzi entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorniamo la tabella principale
                _context.Indirizzi.Update(entity);
            }
            else
            {
                var lang = entity.IndirizziLang?.FirstOrDefault(il => il.Strid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.IndirizziLang
                        .FirstOrDefaultAsync(il =>
                            il.Strid_ID == entity.Str_IDAuto &&
                            il.Strid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna
                        existingLang.Strid_Descrizione = lang.Strid_Descrizione;
                        _context.IndirizziLang.Update(existingLang);
                    }
                    else
                    {
                        // Nuovo record traduzione
                        lang.Strid_ID = entity.Str_IDAuto;
                        _context.IndirizziLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Indirizzi.FindAsync(id);
            if (entity != null)
            {
                _context.Indirizzi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}