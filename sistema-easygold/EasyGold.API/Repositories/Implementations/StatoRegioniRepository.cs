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
    public class StatoRegioniRepository : IStatoRegioniRepository
    {
        private readonly ApplicationDbContext _context;

        public StatoRegioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbStatoRegioni> items, int total)> GetAllAsync(StatoRegioniListRequest request)
        {
            var query = _context.StatoRegioni.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).Include(sr => sr.IdStatoRegioni).ToListAsync();
            return (items, total);
        }

        public async Task<DbStatoRegioni> GetByIdAsync(int id)
        {
            return await _context.StatoRegioni
                .Include(sr => sr.IdStatoRegioni)
                .FirstOrDefaultAsync(sr => sr.Str_IDAuto == id);
        }

        public async Task AddAsync(DbStatoRegioni entity)
        {
            await _context.StatoRegioni.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbStatoRegioni> UpdateAsync(DbStatoRegioni entity)
        {
            _context.StatoRegioni.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.StatoRegioni.FindAsync(id);
            if (entity != null)
            {
                _context.StatoRegioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}