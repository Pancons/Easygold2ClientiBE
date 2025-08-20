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
    public class NumeriRegIVARepository : INumeriRegIVARepository
    {
        private readonly ApplicationDbContext _context;

        public NumeriRegIVARepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbNumeriRegIVA> items, int total)> GetAllAsync(NumeriRegIVAListRequest request)
        {
            var query = _context.NumeriRegIVA.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbNumeriRegIVA> GetByIdAsync(int id)
        {
            return await _context.NumeriRegIVA
                .Include(n => n.RegIVA) // Include the related RegIVA
                .SingleOrDefaultAsync(n => n.RowIDAuto == id);
        }

        public async Task AddAsync(DbNumeriRegIVA entity)
        {
            await _context.NumeriRegIVA.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbNumeriRegIVA entity)
        {
            /*var existingEntity = await _context.NumeriRegIVA.FindAsync(entity.RowIDAuto);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }*/
            _context.NumeriRegIVA.Update(entity);
            await _context.SaveChangesAsync();
            //return entity;
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