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
    public class TipoTagProdottiRepository : ITipoTagProdottiRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoTagProdottiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbTipoTagProdotti>, int total)> GetAllAsync(TipoTagProdottiListRequest filter)
        {
            var query = _context.TipoTagProdotti.AsQueryable();

            int total = await query.CountAsync();

            var results = await query
                .Skip(filter.Offset)
                .Take(filter.Limit)
                .ToListAsync();

            return (results, total);
        }

        public async Task<DbTipoTagProdotti> GetByIdAsync(int id)
        {
            return await _context.TipoTagProdotti.FindAsync(id);
        }

        public async Task AddAsync(DbTipoTagProdotti entity)
        {
            await _context.TipoTagProdotti.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbTipoTagProdotti entity)
        {
            _context.TipoTagProdotti.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipoTagProdotti.FindAsync(id);
            if (entity != null)
            {
                _context.TipoTagProdotti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}