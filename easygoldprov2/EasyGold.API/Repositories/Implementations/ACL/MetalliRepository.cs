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
    public class MetalliRepository : IMetalliRepository
    {
        private readonly ApplicationDbContext _context;

        public MetalliRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbMetalli>, int total)> GetAllAsync(MetalliListRequest filter, string language)
        {
            var query = _context.Metalli
                .Include(m => m.Traduzioni)
                .Include(m => m.Quotazioni)
                .Include(m => m.TipiMetallo)
                .Where(m => m.Traduzioni.Any(tl => tl.MetID_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbMetalli> GetByIdAsync(int id, string language)
        {
            return await _context.Metalli
                .Include(m => m.Traduzioni)
                .Include(m => m.Quotazioni)
                .Include(m => m.TipiMetallo)
                .SingleOrDefaultAsync(m => m.Met_IDAuto == id && m.Traduzioni.Any(tl => tl.MetID_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbMetalli entity, string language)
        {
            if (language == "39")
            {
                await _context.Metalli.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbMetalli();
                await _context.Metalli.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.Traduzioni?.FirstOrDefault(tl => tl.MetID_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.MetID_ID = baseEntity.Met_IDAuto;
                    _context.MetalliLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbMetalli entity, string language)
        {
            if (language == "39")
            {
                _context.Metalli.Update(entity);
            }
            else
            {
                var lang = entity.Traduzioni?.FirstOrDefault(tl => tl.MetID_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.MetalliLang
                        .FirstOrDefaultAsync(tl =>
                            tl.MetID_ID == entity.Met_IDAuto &&
                            tl.MetID_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.MetID_Descrizione = lang.MetID_Descrizione;
                        _context.MetalliLang.Update(existingLang);
                    }
                    else
                    {
                        lang.MetID_ID = entity.Met_IDAuto;
                        _context.MetalliLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Metalli.FindAsync(id);
            if (entity != null)
            {
                _context.Metalli.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}