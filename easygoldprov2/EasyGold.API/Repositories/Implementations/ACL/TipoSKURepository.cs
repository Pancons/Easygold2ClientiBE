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
    public class TipoSKURepository : ITipoSKURepository
    {
        private readonly ApplicationDbContext _context;

        public TipoSKURepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbTipoSKU> items, int total)> GetAllAsync(TipoSKUListRequest request)
        {
            var query = _context.TipoSKU.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbTipoSKU> GetByIdAsync(int id)
        {
            return await _context.TipoSKU.FindAsync(id);
        }

        public async Task AddAsync(DbTipoSKU entity)
        {
            await _context.TipoSKU.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbTipoSKU> UpdateAsync(DbTipoSKU entity)
        {
            _context.TipoSKU.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipoSKU.FindAsync(id);
            if (entity != null)
            {
                _context.TipoSKU.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}