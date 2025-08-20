using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class RegIVARepository : IRegIVARepository
    {
        private readonly ApplicationDbContext _context;

        public RegIVARepository(ApplicationDbContext context)
        {
            _context = context;
        }

       public async Task<(IEnumerable<DbRegIVA> items, int total)> GetAllAsync(RegIVAListRequest request)
        {
            var query = _context.RegIVA.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbRegIVA> GetByIdAsync(int id)
        {
            var entity = await _context.RegIVA
                .Include(r => r.NumeriRegIVA) // Associa i numeri di regIVA
                .SingleOrDefaultAsync(r => r.RowIdAuto == id);
            return entity;
        }

        public async Task AddAsync(DbRegIVA entity)
        {
            await _context.RegIVA.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbRegIVA> UpdateAsync(DbRegIVA entity)
        {
            var existingEntity = await _context.RegIVA.FindAsync(entity.RowIdAuto);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                // Se ci sono relazioni che devono essere aggiornate, gestiscile qui.
                await _context.SaveChangesAsync();
            }
            return existingEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegIVA.FindAsync(id);
            if (entity != null)
            {
                _context.RegIVA.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}