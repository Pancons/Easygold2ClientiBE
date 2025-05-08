using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities.Config;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbConfig>> GetAllAsync()
        {
            return await _context.Configurazioni.AsNoTracking().ToListAsync();
        }

        public async Task<DbConfig> GetByIdAsync(int id)
        {
            return await _context.Configurazioni.AsNoTracking().FirstOrDefaultAsync(x => x.Sys_IDAuto == id);
        }

        public async Task AddAsync(DbConfig entity)
        {
            await _context.Configurazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbConfig entity)
        {
            var existing = await _context.Configurazioni.FindAsync(entity.Sys_IDAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Configurazioni.FindAsync(id);
            if (entity != null)
            {
                _context.Configurazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}