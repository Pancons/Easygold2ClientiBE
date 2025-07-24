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
    public class FiscalePostazioniRepository : IFiscalePostazioniRepository
    {
        private readonly ApplicationDbContext _context;

        public FiscalePostazioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbFiscalePostazioni> items, int total)> GetAllAsync(FiscalePostazioniListRequest request)
        {
            var query = _context.FiscalePostazioni.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbFiscalePostazioni> GetByIdAsync(int id)
        {
            return await _context.FiscalePostazioni.FindAsync(id);
        }

        public async Task AddAsync(DbFiscalePostazioni entity)
        {
            await _context.FiscalePostazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
    
        }

        public async Task<DbFiscalePostazioni> UpdateAsync(DbFiscalePostazioni entity)
        {
           
            _context.FiscalePostazioni.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.FiscalePostazioni.FindAsync(id);
            if (entity != null)
            {
                _context.FiscalePostazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}