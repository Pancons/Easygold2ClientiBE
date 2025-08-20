using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class CausaliRepository : ICausaliRepository
    {
        private readonly ApplicationDbContext _context;

        public CausaliRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCausali>, int total)> GetAllAsync(CausaliListRequest filter, string language)
        {
            var query = _context.CausaliClienti
                .Include(c => c.CausaliLang)
                .Where(c => c.CausaliLang.Any(cl => cl.Cal_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbCausali> GetByIdAsync(int id, string language)
        {
            return await _context.CausaliClienti
                .Include(c => c.CausaliLang)
                .SingleOrDefaultAsync(c => c.Cal_IDAuto == id && c.CausaliLang.Any(cl => cl.Cal_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbCausali entity, string language)
        {
            if (language == "39")
            {
                // Italiano: scriviamo nella tabella principale
                await _context.CausaliClienti.AddAsync(entity);
            }
            else
            {
                // Non italiano: creiamo l'entità base per ottenere l'ID
                var baseEntity = new DbCausali();
                await _context.CausaliClienti.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.CausaliLang?.FirstOrDefault(cl => cl.Cal_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Cal_ID = baseEntity.Cal_IDAuto;
                    _context.CausaliLangClienti.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCausali entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorniamo la tabella principale
                _context.CausaliClienti.Update(entity);
            }
            else
            {
                var lang = entity.CausaliLang?.FirstOrDefault(cl => cl.Cal_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.CausaliLangClienti
                        .FirstOrDefaultAsync(cl =>
                            cl.Cal_ID == entity.Cal_IDAuto &&
                            cl.Cal_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna la traduzione
                        existingLang.Cal_Descrizione = lang.Cal_Descrizione;
                        _context.CausaliLangClienti.Update(existingLang);
                    }
                    else
                    {
                        // Aggiungi nuova traduzione
                        lang.Cal_ID = entity.Cal_IDAuto;
                        _context.CausaliLangClienti.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CausaliClienti.FindAsync(id);
            if (entity != null)
            {
                _context.CausaliClienti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}