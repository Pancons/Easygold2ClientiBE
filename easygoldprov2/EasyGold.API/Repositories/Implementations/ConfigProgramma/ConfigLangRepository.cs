using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities.Config;
using EasyGold.API.Repositories.Interfaces.ConfigProgramma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations.ConfigProgramma
{
    public class ConfigLangRepository : IConfigLangRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigLangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbConfigLang>> GetAllAsync()
        {
            return await _context.ConfigLag.AsNoTracking().ToListAsync();
        }

        public async Task<DbConfigLang> GetByIdAsync(int isoNum, int id)
        {
            return await _context.ConfigLag.AsNoTracking()
                .FirstOrDefaultAsync(x => x.SysLng_ISONum == isoNum && x.SysLng_ID == id);
        }

        public async Task AddAsync(DbConfigLang entity)
        {
            await _context.ConfigLag.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbConfigLang entity)
        {
            var existing = await _context.ConfigLag
                .FirstOrDefaultAsync(x => x.SysLng_ISONum == entity.SysLng_ISONum && x.SysLng_ID == entity.SysLng_ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int isoNum, int id)
        {
            var entity = await _context.ConfigLag
                .FirstOrDefaultAsync(x => x.SysLng_ISONum == isoNum && x.SysLng_ID == id);
            if (entity != null)
            {
                _context.ConfigLag.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}