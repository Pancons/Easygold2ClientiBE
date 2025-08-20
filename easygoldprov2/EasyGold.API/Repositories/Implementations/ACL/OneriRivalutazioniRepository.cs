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
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;


namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class OneriRivalutazioniRepository : IOneriRivalutazioniRepository
    {
        private readonly ApplicationDbContext _context;

        public OneriRivalutazioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbOneriRivalutazioni>, int total)> GetAllAsync(OneriRivalutazioniListRequest filter, string language)
        {
            var query = _context.OneriRivalutazioni
                .Include(o => o.OneriRivalutazioniLang)
                .Where(o => o.OneriRivalutazioniLang.Any(ol => ol.OnrId_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();
            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbOneriRivalutazioni> GetByIdAsync(int id, string language)
        {
            return await _context.OneriRivalutazioni
                .Include(o => o.OneriRivalutazioniLang)
                .SingleOrDefaultAsync(o => o.Onr_IDAuto == id && o.OneriRivalutazioniLang.Any(ol => ol.OnrId_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbOneriRivalutazioni entity, string language)
        {
            if (language == "39")
            {
                await _context.OneriRivalutazioni.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbOneriRivalutazioni();
                /*{
                    Onr_Modifica = entity.Onr_Modifica,
                    Onr_Fee = entity.Onr_Fee,
                    Onr_Ordinamento = entity.Onr_Ordinamento,
                    Onr_Annulla = entity.Onr_Annulla
                };*/

                await _context.OneriRivalutazioni.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.OneriRivalutazioniLang?.FirstOrDefault(ol => ol.OnrId_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.OnrId_ID = baseEntity.Onr_IDAuto;
                    _context.OneriRivalutazioniLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbOneriRivalutazioni entity, string language)
        {
            if (language == "39")
            {
                _context.OneriRivalutazioni.Update(entity);
            }
            else
            {
                var lang = entity.OneriRivalutazioniLang?.FirstOrDefault(ol => ol.OnrId_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.OneriRivalutazioniLang
                        .FirstOrDefaultAsync(ol =>
                            ol.OnrId_ID == entity.Onr_IDAuto &&
                            ol.OnrId_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.OnrId_Descrizione = lang.OnrId_Descrizione;
                        _context.OneriRivalutazioniLang.Update(existingLang);
                    }
                    else
                    {
                        lang.OnrId_ID = entity.Onr_IDAuto;
                        _context.OneriRivalutazioniLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.OneriRivalutazioni.FindAsync(id);
            if (entity != null)
            {
                _context.OneriRivalutazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}