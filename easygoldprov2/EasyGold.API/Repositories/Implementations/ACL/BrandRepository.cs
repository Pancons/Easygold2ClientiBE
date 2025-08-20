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
using EasyGold.Web2.Models.Cliente.Brand;
using EasyGold.Web2.Models.Cliente.Entities.Brand;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbBrand>, int total)> GetAllAsync(BrandListRequest filter, string language)
        {
            var query = _context.Brands
                .Include(b => b.BrandLang)
                .Where(b => b.BrandLang.Any(bl => bl.BrdId_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbBrand> GetByIdAsync(int id, string language)
        {
            return await _context.Brands
                .Include(b => b.BrandLang)
                .SingleOrDefaultAsync(b => b.Brd_IDAuto == id && b.BrandLang.Any(bl => bl.BrdId_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbBrand entity, string language)
        {
            if (language == "39")
            {
                // Italiano: inserisci nella tabella principale
                await _context.Brands.AddAsync(entity);
            }
            else
            {
                // Lingua diversa: inserisci il brand base (per ottenere ID)
                var baseEntity = new DbBrand();
                await _context.Brands.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.BrandLang?.FirstOrDefault(bl => bl.BrdId_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.BrdId_ID = baseEntity.Brd_IDAuto;
                    _context.BrandLangs.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbBrand entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorna direttamente la tabella principale
                _context.Brands.Update(entity);
            }
            else
            {
                var lang = entity.BrandLang?.FirstOrDefault(bl => bl.BrdId_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.BrandLangs
                        .FirstOrDefaultAsync(bl =>
                            bl.BrdId_ID == entity.Brd_IDAuto &&
                            bl.BrdId_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.BrdId_Brand = lang.BrdId_Brand;
                        _context.BrandLangs.Update(existingLang);
                    }
                    else
                    {
                        lang.BrdId_ID = entity.Brd_IDAuto;
                        _context.BrandLangs.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Brands.FindAsync(id);
            if (entity != null)
            {
                _context.Brands.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}