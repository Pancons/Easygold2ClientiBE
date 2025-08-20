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
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class CauOrdinamentoRepository : ICauOrdinamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public CauOrdinamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbCauOrdinamento>, int total)> GetAllAsync(CauOrdinamentoListRequest filter)
        {
            var query = _context.CauOrdinamento.AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbCauOrdinamento> GetByIdAsync(int id)
        {
            return await _context.CauOrdinamento.FindAsync(id);
        }

        public async Task AddAsync(DbCauOrdinamento entity)
        {
            await _context.CauOrdinamento.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCauOrdinamento entity)
        {
            _context.CauOrdinamento.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CauOrdinamento.FindAsync(id);
            if (entity != null)
            {
                _context.CauOrdinamento.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}