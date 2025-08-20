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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly ApplicationDbContext _context;

        public ProvinceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbProvince>, int total)> GetAllAsync(ProvinceListRequest filter, string language)
        {
            var query = _context.Province
                .Include(p => p.ProvinceLang)
                .Where(p => p.ProvinceLang.Any(pl => pl.Strid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbProvince> GetByIdAsync(int id, string language)
        {
            return await _context.Province
                .Include(p => p.ProvinceLang)
                .SingleOrDefaultAsync(p => p.Str_IDAuto == id && p.ProvinceLang.Any(pl => pl.Strid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbProvince entity, string language)
        {
            if (language == "39")
            {
                // Italiano: scriviamo nella tabella principale
                await _context.Province.AddAsync(entity);
            }
            else
            {
                // Non italiano: creiamo l'entità base per ottenere l'ID
                var baseEntity = new DbProvince();
                await _context.Province.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.ProvinceLang?.FirstOrDefault(pl => pl.Strid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Strid_ID = baseEntity.Str_IDAuto;
                    _context.ProvinceLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbProvince entity, string language)
        {
            if (language == "39")
            {
                // Italiano: aggiorniamo la tabella principale
                _context.Province.Update(entity);
            }
            else
            {
                var lang = entity.ProvinceLang?.FirstOrDefault(pl => pl.Strid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.ProvinceLang
                        .FirstOrDefaultAsync(pl =>
                            pl.Strid_ID == entity.Str_IDAuto &&
                            pl.Strid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        // Aggiorna
                        existingLang.Strid_Descrizione = lang.Strid_Descrizione;
                        _context.ProvinceLang.Update(existingLang);
                    }
                    else
                    {
                        // Nuovo record traduzione
                        lang.Strid_ID = entity.Str_IDAuto;
                        _context.ProvinceLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Province.FindAsync(id);
            if (entity != null)
            {
                _context.Province.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}