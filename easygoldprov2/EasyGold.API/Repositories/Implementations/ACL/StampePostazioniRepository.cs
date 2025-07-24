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
    public class StampePostazioniRepository : IStampePostazioniRepository
    {
        private readonly ApplicationDbContext _context;

        public StampePostazioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbStampePostazioni> items, int total)> GetAllAsync(StampePostazioniListRequest request)
        {
            var query = _context.StampePostazioni.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbStampePostazioni> GetByIdAsync(int id)
        {
            var entity = await _context.StampePostazioni.FindAsync(id);
            return entity;
        }

        public async Task AddAsync(DbStampePostazioni entity)
        {
            await _context.StampePostazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
          
        }

        public async Task<DbStampePostazioni> UpdateAsync(DbStampePostazioni entity)
        {
            _context.StampePostazioni.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.StampePostazioni.FindAsync(id);
            if (entity != null)
            {
                _context.StampePostazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}