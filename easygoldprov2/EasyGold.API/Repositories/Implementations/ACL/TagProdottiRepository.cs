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
    public class TagProdottiRepository : ITagProdottiRepository
    {
        private readonly ApplicationDbContext _context;

        public TagProdottiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbTagProdotti>, int total)> GetAllAsync(TagProdottiListRequest filter, string language)
        {
            var query = _context.TagProdotti
                .Include(t => t.Traduzioni)
                .Where(t => t.Traduzioni.Any(trad => trad.EtpId_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbTagProdotti> GetByIdAsync(int id, string language)
        {
            return await _context.TagProdotti
                .Include(t => t.Traduzioni)
                .SingleOrDefaultAsync(t => t.Etp_IDAuto == id && t.Traduzioni.Any(trad => trad.EtpId_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbTagProdotti entity, string language)
        {
            if (language == "39")
            {
                await _context.TagProdotti.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbTagProdotti();
                await _context.TagProdotti.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var translation = entity.Traduzioni?.FirstOrDefault(trad => trad.EtpId_ISONum.ToString() == language);
                if (translation != null)
                {
                    translation.EtpId_ID = baseEntity.Etp_IDAuto;
                    _context.TagProdottiLang.Add(translation);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTagProdotti entity, string language)
        {
            if (language == "39")
            {
                _context.TagProdotti.Update(entity);
            }
            else
            {
                var translation = entity.Traduzioni?.FirstOrDefault(trad => trad.EtpId_ISONum.ToString() == language);
                if (translation != null)
                {
                    var existingTranslation = await _context.TagProdottiLang
                        .FirstOrDefaultAsync(trad =>
                            trad.EtpId_ID == entity.Etp_IDAuto &&
                            trad.EtpId_ISONum.ToString() == language);

                    if (existingTranslation != null)
                    {
                        existingTranslation.EtpId_Descrizione = translation.EtpId_Descrizione;
                        _context.TagProdottiLang.Update(existingTranslation);
                    }
                    else
                    {
                        translation.EtpId_ID = entity.Etp_IDAuto;
                        _context.TagProdottiLang.Add(translation);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TagProdotti.FindAsync(id);
            if (entity != null)
            {
                _context.TagProdotti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}