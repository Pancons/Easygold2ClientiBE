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
    public class IdISONazioniRepository : IIdISONazioniRepository
    {
        private readonly ApplicationDbContext _context;

        public IdISONazioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbIdISONazioni> items, int total)> GetAllAsync(IdISONazioniListRequest request)
        {
            var query = _context.IdISONazioni.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbIdISONazioni> GetByIdAsync(int id)
        {
            return await _context.IdISONazioni.FindAsync(id);
        }

        public async Task AddAsync(DbIdISONazioni entity)
        {
            await _context.IdISONazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbIdISONazioni> UpdateAsync(DbIdISONazioni entity)
        {
            _context.IdISONazioni.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.IdISONazioni.FindAsync(id);
            if (entity != null)
            {
                _context.IdISONazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}