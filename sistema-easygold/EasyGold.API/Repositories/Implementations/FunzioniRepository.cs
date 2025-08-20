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
    public class FunzioniRepository : IFunzioniRepository
    {
        private readonly ApplicationDbContext _context;

        public FunzioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbFunzioni>, int total)> GetAllAsync(FunzioniListRequest filter, string language)
        {
            var query = _context.Funzioni
                .Include(f => f.FunzioniLang)
                .Where(f => f.FunzioniLang.Any(fl => fl.Ablid_ISONum.ToString() == language))
                .AsQueryable();


            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbFunzioni> GetByIdAsync(int id, string language)
        {
            return await _context.Funzioni
                .Include(f => f.FunzioniLang)
                .SingleOrDefaultAsync(f => f.Abl_IDAuto == id && f.FunzioniLang.Any(fl => fl.Ablid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbFunzioni entity, string language)
        {
            if (language == "39")
            {
                // Italiano: scriviamo nella tabella principale
                await _context.Funzioni.AddAsync(entity);
            }
            else
            {
                // Non italiano: creiamo l'entità base per ottenere l'ID
                var baseEntity = new DbFunzioni();
                await _context.Funzioni.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.FunzioniLang?.FirstOrDefault(fl => fl.Ablid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Ablid_ID = baseEntity.Abl_IDAuto;
                    _context.FunzioniLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbFunzioni entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorniamo la tabella principale
                _context.Funzioni.Update(entity);
            }
            else
            {
                var lang = entity.FunzioniLang?.FirstOrDefault(fl => fl.Ablid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.FunzioniLang
                        .FirstOrDefaultAsync(fl =>
                            fl.Ablid_ID == entity.Abl_IDAuto &&
                            fl.Ablid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna
                        existingLang.Ablid_DescFunzione = lang.Ablid_DescFunzione;
                        existingLang.Ablid_descFunzioneEstesa = lang.Ablid_descFunzioneEstesa;
                        _context.FunzioniLang.Update(existingLang);
                    }
                    else
                    {
                        // Nuovo record traduzione
                        lang.Ablid_ID = entity.Abl_IDAuto;
                        _context.FunzioniLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Funzioni.FindAsync(id);
            if (entity != null)
            {
                _context.Funzioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}