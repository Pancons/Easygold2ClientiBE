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
    public class ListiniProdottoRepository : IListiniProdottoRepository
    {
        private readonly ApplicationDbContext _context;

        public ListiniProdottoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbListiniProdotto>, int total)> GetAllAsync(ListiniProdottoListRequest filter, string language)
        {
            var query = _context.ListiniProdotto
                .Include(lp => lp.ListiniProdottoLang)
                .Where(lp => lp.ListiniProdottoLang.Any(lpl => lpl.Lisid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbListiniProdotto> GetByIdAsync(int id, string language)
        {
            return await _context.ListiniProdotto
                .Include(lp => lp.ListiniProdottoLang)
                .SingleOrDefaultAsync(lp => lp.Lis_IDAuto == id && lp.ListiniProdottoLang.Any(lpl => lpl.Lisid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbListiniProdotto entity, string language)
        {
            if (language == "39")
            {
                // Italiano: scriviamo nella tabella principale
                await _context.ListiniProdotto.AddAsync(entity);
            }
            else
            {
                // Non italiano: creiamo l'entità base per ottenere l'ID
                var baseEntity = new DbListiniProdotto();
                await _context.ListiniProdotto.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.ListiniProdottoLang?.FirstOrDefault(lpl => lpl.Lisid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Lisid_ID = baseEntity.Lis_IDAuto;
                    _context.ListiniProdottoLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbListiniProdotto entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorniamo la tabella principale
                _context.ListiniProdotto.Update(entity);
            }
            else
            {
                var lang = entity.ListiniProdottoLang?.FirstOrDefault(lpl => lpl.Lisid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.ListiniProdottoLang
                        .FirstOrDefaultAsync(lpl =>
                            lpl.Lisid_ID == entity.Lis_IDAuto &&
                            lpl.Lisid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna
                        existingLang.Lisid_Descrizione = lang.Lisid_Descrizione;
                        _context.ListiniProdottoLang.Update(existingLang);
                    }
                    else
                    {
                        // Nuovo record traduzione
                        lang.Lisid_ID = entity.Lis_IDAuto;
                        _context.ListiniProdottoLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ListiniProdotto.FindAsync(id);
            if (entity != null)
            {
                _context.ListiniProdotto.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}