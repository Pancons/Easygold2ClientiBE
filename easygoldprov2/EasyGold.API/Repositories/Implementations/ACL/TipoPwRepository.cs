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
    public class TipoPwRepository : ITipoPwRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoPwRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbTipoPw> items, int total)> GetAllAsync(TipoPwListRequest request)
        {
            var query = _context.TipoPw.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbTipoPw> GetByIdAsync(int id)
        {
            var entity = await _context.TipoPw.FindAsync(id);
            return entity == null ? null : new DbTipoPw
            {
                Tpp_IDAuto = entity.Tpp_IDAuto,
                Tpp_TipoPw = entity.Tpp_TipoPw,
             
            };
        }

        public async Task AddAsync(DbTipoPw entity)
        {
            await _context.TipoPw.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbTipoPw> UpdateAsync(DbTipoPw entity)
        {
            _context.TipoPw.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipoPw.FindAsync(id);
            if (entity != null)
            {
                _context.TipoPw.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}