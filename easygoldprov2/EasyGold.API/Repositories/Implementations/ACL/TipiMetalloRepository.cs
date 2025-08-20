using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;


namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class TipiMetalloRepository : ITipiMetalloRepository
    {
        private readonly ApplicationDbContext _context;

        public TipiMetalloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbTipiMetallo>, int total)> GetAllAsync(TipiMetalloListRequest filter, string language)
        {
            var query = _context.TipiMetallo
                .Include(t => t.Traduzioni)
                .Where(t => t.Traduzioni.Any(tl => tl.TimID_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbTipiMetallo> GetByIdAsync(int id, string language)
        {
            return await _context.TipiMetallo
                .Include(t => t.Traduzioni)
                .SingleOrDefaultAsync(t => t.Tim_IDAuto == id && t.Traduzioni.Any(tl => tl.TimID_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbTipiMetallo entity, string language)
        {
            if (language == "39")
            {
                // Italiano: inserisci direttamente nella tabella principale
                await _context.TipiMetallo.AddAsync(entity);
            }
            else
            {
                // Lingua diversa: inserisci il tipo base (per ottenere ID)
                var baseEntity = new DbTipiMetallo
                {
                    Tim_ID = entity.Tim_ID,
                    Tim_Descrizione = entity.Tim_Descrizione,
                    Tim_Annullato = entity.Tim_Annullato
                };
                await _context.TipiMetallo.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.Traduzioni?.FirstOrDefault(tl => tl.TimID_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.TimID_ID = baseEntity.Tim_IDAuto;
                    _context.Set<DbTipiMetalloLang>().Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTipiMetallo entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorna direttamente nella tabella principale
                _context.TipiMetallo.Update(entity);
            }
            else
            {
                var lang = entity.Traduzioni?.FirstOrDefault(tl => tl.TimID_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.Set<DbTipiMetalloLang>()
                        .FirstOrDefaultAsync(tl =>
                            tl.TimID_ID == entity.Tim_IDAuto &&
                            tl.TimID_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.TimID_Descrizione = lang.TimID_Descrizione;
                        _context.Set<DbTipiMetalloLang>().Update(existingLang);
                    }
                    else
                    {
                        lang.TimID_ID = entity.Tim_IDAuto;
                        _context.Set<DbTipiMetalloLang>().Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipiMetallo.FindAsync(id);
            if (entity != null)
            {
                _context.TipiMetallo.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}