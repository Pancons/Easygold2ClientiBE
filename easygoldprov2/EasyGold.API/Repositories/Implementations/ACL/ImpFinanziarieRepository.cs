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
    public class ImpFinanziarieRepository : IImpFinanziarieRepository
    {
        private readonly ApplicationDbContext _context;

        public ImpFinanziarieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbImpFinanziarie>, int total)> GetAllAsync(ImpFinanziarieListRequest filter, string language)
        {
            var query = _context.ImpreseFinanziarie
                .Include(i => i.ImpFinanziarieLang)
                .Where(i => i.ImpFinanziarieLang.Any(lang => lang.Imfid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbImpFinanziarie> GetByIdAsync(int id, string language)
        {
            return await _context.ImpreseFinanziarie
                .Include(i => i.ImpFinanziarieLang)
                .SingleOrDefaultAsync(i => i.Imf_IDAuto == id && i.ImpFinanziarieLang.Any(lang => lang.Imfid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbImpFinanziarie entity, string language)
        {
            if (language == "39")
            {
                await _context.ImpreseFinanziarie.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbImpFinanziarie();
                await _context.ImpreseFinanziarie.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.ImpFinanziarieLang?.FirstOrDefault(l => l.Imfid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Imfid_ID = baseEntity.Imf_IDAuto;
                    _context.ImpreseFinanziarieLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbImpFinanziarie entity, string language)
        {
            if (language == "39")
            {
                _context.ImpreseFinanziarie.Update(entity);
            }
            else
            {
                var lang = entity.ImpFinanziarieLang?.FirstOrDefault(l => l.Imfid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.ImpreseFinanziarieLang
                        .FirstOrDefaultAsync(l => l.Imfid_ID == entity.Imf_IDAuto && l.Imfid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.Imfid_Descrizione = lang.Imfid_Descrizione;
                        _context.ImpreseFinanziarieLang.Update(existingLang);
                    }
                    else
                    {
                        lang.Imfid_ID = entity.Imf_IDAuto;
                        _context.ImpreseFinanziarieLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ImpreseFinanziarie.FindAsync(id);
            if (entity != null)
            {
                _context.ImpreseFinanziarie.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}