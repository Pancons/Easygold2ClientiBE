using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities.NumeriRegIVA;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
{
    public class NumeriRegIVARepository : INumeriRegIVARepository
    {
        private readonly ApplicationDbContext _context;

        public NumeriRegIVARepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbNumeriRegIVA>> GetAllAsync()
        {
            return await _context.NumeriRegIVA.AsNoTracking().ToListAsync();
        }

        public async Task<DbNumeriRegIVA> GetByIdAsync(int id)
        {
            return await _context.NumeriRegIVA.AsNoTracking().FirstOrDefaultAsync(x => x.RowIDAuto == id);
        }

        public async Task AddAsync(DbNumeriRegIVA entity)
        {
            await _context.NumeriRegIVA.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNumeriRegIVA entity)
        {
            var existing = await _context.NumeriRegIVA.FindAsync(entity.RowIDAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.NumeriRegIVA.FindAsync(id);
            if (entity != null)
            {
                _context.NumeriRegIVA.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}