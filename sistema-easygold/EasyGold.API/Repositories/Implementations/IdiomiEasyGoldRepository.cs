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
using EasyGold.API.Infrastructure;


namespace EasyGold.API.Repositories.Implementations
{
    public class IdiomiEasyGoldRepository : IIdiomiEasyGoldRepository
    {
        private readonly ApplicationDbContext _context;

        public IdiomiEasyGoldRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbIdiomiEasyGold>, int total)> GetAllAsync(IdiomiEasyGoldListRequest filter)
        {
            var query = _context.IdiomiEasyGold.AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbIdiomiEasyGold> GetByIdAsync(int id)
        {
            return await _context.IdiomiEasyGold.FindAsync(id);
        }

        public async Task AddAsync(DbIdiomiEasyGold entity)
        {
            await _context.IdiomiEasyGold.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbIdiomiEasyGold entity)
        {
            _context.IdiomiEasyGold.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.IdiomiEasyGold.FindAsync(id);
            if (entity != null)
            {
                _context.IdiomiEasyGold.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}