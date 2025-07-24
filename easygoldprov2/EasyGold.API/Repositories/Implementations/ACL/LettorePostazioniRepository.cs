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
    public class LettorePostazioniRepository : ILettorePostazioniRepository
    {
        private readonly ApplicationDbContext _context;

        public LettorePostazioniRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbLettorePostazioni>, int total)> GetAllAsync(LettorePostazioniListRequest filter)
        {
            var query = _context.LettorePostazioni.AsQueryable();

        

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbLettorePostazioni> GetByIdAsync(int id)
        {
            return await _context.LettorePostazioni.FindAsync(id);
        }

        public async Task AddAsync(DbLettorePostazioni entity)
        {
            await _context.LettorePostazioni.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbLettorePostazioni entity)
        {
            _context.LettorePostazioni.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.LettorePostazioni.FindAsync(id);
            if (entity != null)
            {
                _context.LettorePostazioni.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}