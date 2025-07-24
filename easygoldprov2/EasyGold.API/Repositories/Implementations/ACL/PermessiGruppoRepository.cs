using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class PermessiGruppoRepository : IPermessiGruppoRepository
    {
        private readonly ApplicationDbContext _context;

        public PermessiGruppoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbPermessiGruppo>, int total)> GetAllAsync(PermessiGruppoListRequest filter)
        {
            var query = _context.PermessiGruppo.AsQueryable();

         
            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbPermessiGruppo> GetByIdAsync(int id)
        {
            return await _context.PermessiGruppo.FindAsync(id);
        }

        public async Task AddAsync(DbPermessiGruppo entity)
        {
            await _context.PermessiGruppo.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbPermessiGruppo entity)
        {
            _context.PermessiGruppo.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PermessiGruppo.FindAsync(id);
            if (entity != null)
            {
                _context.PermessiGruppo.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}