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
    public class ListiniTabellaRepository : IListiniTabellaRepository
    {
        private readonly ApplicationDbContext _context;

        public ListiniTabellaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbListiniTabella>, int total)> GetAllAsync(ListiniTabellaListRequest filter, string language)
        {
            var query = _context.ListiniTabella
                .Include(lt => lt.ListiniTabellaLang)
                .Where(lt => lt.ListiniTabellaLang.Any(l => l.Tbsid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbListiniTabella> GetByIdAsync(int id, string language)
        {
            return await _context.ListiniTabella
                .Include(lt => lt.ListiniTabellaLang)
                .SingleOrDefaultAsync(lt => lt.Lst_IDAuto == id && lt.ListiniTabellaLang.Any(l => l.Tbsid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbListiniTabella entity, string language)
        {
            if (language == "39")
            {
                // Italiano: scriviamo nella tabella principale
                await _context.ListiniTabella.AddAsync(entity);
            }
            else
            {
                // Non italiano: creiamo l'entità base per ottenere l'ID
                var baseEntity = new DbListiniTabella();
                await _context.ListiniTabella.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.ListiniTabellaLang?.FirstOrDefault(l => l.Tbsid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Tbsid_ID = baseEntity.Lst_IDAuto;
                    _context.ListiniTabellaLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbListiniTabella entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorniamo la tabella principale
                _context.ListiniTabella.Update(entity);
            }
            else
            {
                var lang = entity.ListiniTabellaLang?.FirstOrDefault(l => l.Tbsid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.ListiniTabellaLang
                        .FirstOrDefaultAsync(l =>
                            l.Tbsid_ID == entity.Lst_IDAuto &&
                            l.Tbsid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna
                        existingLang.Tbsid_Descrizione = lang.Tbsid_Descrizione;
                        _context.ListiniTabellaLang.Update(existingLang);
                    }
                    else
                    {
                        // Nuovo record traduzione
                        lang.Tbsid_ID = entity.Lst_IDAuto;
                        _context.ListiniTabellaLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ListiniTabella.FindAsync(id);
            if (entity != null)
            {
                _context.ListiniTabella.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}