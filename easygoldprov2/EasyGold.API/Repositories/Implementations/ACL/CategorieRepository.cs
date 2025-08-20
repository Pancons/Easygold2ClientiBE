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
using EasyGold.Web2.Models.Cliente.CategorieProdotto;
using EasyGold.Web2.Models.Cliente.Entities.CategorieProdotto;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly ApplicationDbContext _context;

        public CategorieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCategorie>, int total)> GetAllAsync(CategorieListRequest filter, string language)
        {
            var query = _context.Categorie
                .Include(c => c.CategorieLang)
                .Where(c => c.CategorieLang.Any(cl => cl.Catid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbCategorie> GetByIdAsync(int id, string language)
        {
            return await _context.Categorie
                .Include(c => c.CategorieLang)
                .SingleOrDefaultAsync(c => c.Cat_IDAuto == id && c.CategorieLang.Any(cl => cl.Catid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbCategorie entity, string language)
        {
            if (language == "39")
            {
                await _context.Categorie.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbCategorie();
                await _context.Categorie.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.CategorieLang?.FirstOrDefault(cl => cl.Catid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Catid_ID = baseEntity.Cat_IDAuto;
                    _context.CategorieLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCategorie entity, string language)
        {
            if (language == "39")
            {
                _context.Categorie.Update(entity);
            }
            else
            {
                var lang = entity.CategorieLang?.FirstOrDefault(cl => cl.Catid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.CategorieLang
                        .FirstOrDefaultAsync(cl =>
                            cl.Catid_ID == entity.Cat_IDAuto &&
                            cl.Catid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.Catid_DescCategoria = lang.Catid_DescCategoria;
                        _context.CategorieLang.Update(existingLang);
                    }
                    else
                    {
                        lang.Catid_ID = entity.Cat_IDAuto;
                        _context.CategorieLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categorie.FindAsync(id);
            if (entity != null)
            {
                _context.Categorie.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}