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
    public class ValuteRepository : IValuteRepository
    {
        private readonly ApplicationDbContext _context;

        public ValuteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbValute>, int total)> GetAllAsync(ValuteListRequest filter, string language)
        {
            var query = _context.Valute
                .Include(v => v.ValuteLang)
                .Where(v => v.ValuteLang.Any(vl => vl.Valid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbValute> GetByIdAsync(int id, string language)
        {
            return await _context.Valute
                .Include(v => v.ValuteLang)
                .SingleOrDefaultAsync(v => v.Val_IDAuto == id && v.ValuteLang.Any(vl => vl.Valid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbValute entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiungere alla tabella principale
                await _context.Valute.AddAsync(entity);
            }
            else
            {
                // Non italiano: creiamo l'entità base per ottenere l'ID
                var baseEntity = new DbValute();
                await _context.Valute.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.ValuteLang?.FirstOrDefault(vl => vl.Valid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Valid_ID = baseEntity.Val_IDAuto;
                    _context.ValuteLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbValute entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorniamo la tabella principale
                _context.Valute.Update(entity);
            }
            else
            {
                var lang = entity.ValuteLang?.FirstOrDefault(vl => vl.Valid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.ValuteLang
                        .FirstOrDefaultAsync(vl => vl.Valid_ID == entity.Val_IDAuto && vl.Valid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna
                        existingLang.Valid_Descrizione = lang.Valid_Descrizione;
                        _context.ValuteLang.Update(existingLang);
                    }
                    else
                    {
                        // Nuovo record traduzione
                        lang.Valid_ID = entity.Val_IDAuto;
                        _context.ValuteLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Valute.FindAsync(id);
            if (entity != null)
            {
                _context.Valute.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}