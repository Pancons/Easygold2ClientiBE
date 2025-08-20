using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbConfig>, int)> GetAllAsync(ConfigListRequest filter, string language)
        {
            var query = _context.Config
                .Include(c => c.ConfigLang)
                .Where(c => c.ConfigLang.Any(cl => cl.Sysid_ISONum.ToString() == language))
                .AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbConfig> GetByIdAsync(int id, string language)
        {
            return await _context.Config
                .Include(c => c.ConfigLang)
                .SingleOrDefaultAsync(c => c.Sys_IDAuto == id && c.ConfigLang.Any(cl => cl.Sysid_ISONum.ToString() == language));
        }

        public async Task AddAsync(DbConfig entity, string language)
        {
            if (language == "39")
            {
                await _context.Config.AddAsync(entity);
            }
            else
            {
                var baseEntity = new DbConfig();
                await _context.Config.AddAsync(baseEntity);
                await _context.SaveChangesAsync();

                var lang = entity.ConfigLang?.FirstOrDefault(cl => cl.Sysid_ISONum.ToString() == language);
                if (lang != null)
                {
                    lang.Sysid_ID = baseEntity.Sys_IDAuto;
                    _context.ConfigLang.Add(lang);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbConfig entity, string language)
        {
            if (language == "39")
            {
                _context.Config.Update(entity);
            }
            else
            {
                var lang = entity.ConfigLang?.FirstOrDefault(cl => cl.Sysid_ISONum.ToString() == language);
                if (lang != null)
                {
                    var existingLang = await _context.ConfigLang
                        .FirstOrDefaultAsync(cl =>
                            cl.Sysid_ID == entity.Sys_IDAuto &&
                            cl.Sysid_ISONum.ToString() == language);

                    if (existingLang != null)
                    {
                        existingLang.Sysid_NomeCampo = lang.Sysid_NomeCampo;
                        _context.ConfigLang.Update(existingLang);
                    }
                    else
                    {
                        lang.Sysid_ID = entity.Sys_IDAuto;
                        _context.ConfigLang.Add(lang);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Config.FindAsync(id);
            if (entity != null)
            {
                _context.Config.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}