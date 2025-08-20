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
using EasyGold.Web2.Models.Cliente.Metalli;
using EasyGold.Web2.Models.Cliente.Entities.Metalli;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;


namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class QuotazioneMetalliRepository : IQuotazioneMetalliRepository
    {
        private readonly ApplicationDbContext _context;

        public QuotazioneMetalliRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbQuotazioneMetalli> items, int total)> GetAllAsync(QuotazioneMetalliListRequest request)
        {
            var query = _context.QuotazioneMetalli.AsQueryable();
            int total = await query.CountAsync();
            var items = await query
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToListAsync();
            return (items, total);
        }

        public async Task<DbQuotazioneMetalli> GetByIdAsync(int id)
        {
            return await _context.QuotazioneMetalli.FindAsync(id);
        }

        public async Task AddAsync(DbQuotazioneMetalli entity)
        {
            await _context.QuotazioneMetalli.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbQuotazioneMetalli> UpdateAsync(DbQuotazioneMetalli entity)
        {
            _context.QuotazioneMetalli.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.QuotazioneMetalli.FindAsync(id);
            if (entity != null)
            {
                _context.QuotazioneMetalli.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}