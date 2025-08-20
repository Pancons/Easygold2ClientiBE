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
    public class ISONazioniRepository : IISONazioniRepository
    {
        private readonly ApplicationDbContext _context;

        public ISONazioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbISONazioni> items, int total)> GetAllAsync(ISONazioniListRequest request)
        {
            var query = _context.ISONazioni.AsQueryable();

            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();

            return (items, total);
        }

        public async Task<DbISONazioni> GetByIdAsync(int id)
        {
            return await _context.ISONazioni.FindAsync(id);
        }

        public async Task AddAsync(DbISONazioni entity)
        {
            await _context.ISONazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbISONazioni> UpdateAsync(DbISONazioni entity)
        {
            _context.ISONazioni.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ISONazioni.FindAsync(id);
            if (entity != null)
            {
                _context.ISONazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}