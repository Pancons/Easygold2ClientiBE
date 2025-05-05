using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
{
    public class ConfigLagRepository : IConfigLagRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigLagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbConfigLag>> GetAllAsync()
        {
            return await _context.ConfigLag.AsNoTracking().ToListAsync();
        }

        public async Task<DbConfigLag> GetByIdAsync(int isoNum, int id)
        {
            return await _context.ConfigLag.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Sysid_ISONum == isoNum && x.Sysid_ID == id);
        }

        public async Task AddAsync(DbConfigLag entity)
        {
            await _context.ConfigLag.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbConfigLag entity)
        {
            var existing = await _context.ConfigLag
                .FirstOrDefaultAsync(x => x.Sysid_ISONum == entity.Sysid_ISONum && x.Sysid_ID == entity.Sysid_ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int isoNum, int id)
        {
            var entity = await _context.ConfigLag
                .FirstOrDefaultAsync(x => x.Sysid_ISONum == isoNum && x.Sysid_ID == id);
            if (entity != null)
            {
                _context.ConfigLag.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}