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
    public class TipoPermessoRepository : ITipoPermessoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoPermessoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbTipoPermesso> items, int total)> GetAllAsync(TipoPermessoListRequest request)
        {
            var query = _context.TipoPermesso.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbTipoPermesso> GetByIdAsync(int id)
        {
            var entity = await _context.TipoPermesso.FindAsync(id); 
            return entity == null ? null : new DbTipoPermesso
            {
                Tpa_IDAuto = entity.Tpa_IDAuto,
                Tpa_TipoPermesso = entity.Tpa_TipoPermesso,
                Tpa_LivelloPermesso = entity.Tpa_LivelloPermesso,
                PermessiGruppo = entity.PermessiGruppo.Select(pg => new DbPermessiGruppo
                {
                    Abg_IDAuto = pg.Abg_IDAuto,
                    Abg_IDGruppo = pg.Abg_IDGruppo,
                    Abg_IDFunzione = pg.Abg_IDFunzione,
                    Abg_IDTipoPermesso = pg.Abg_IDTipoPermesso
                }).ToList()
            };
        }

        public async Task AddAsync(DbTipoPermesso entity)
        {
            
            await _context.TipoPermesso.AddAsync(entity);
            await _context.SaveChangesAsync();
           
        }

        public async Task<DbTipoPermesso> UpdateAsync(DbTipoPermesso entity)
        {
            _context.TipoPermesso.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TipoPermesso.FindAsync(id);
            if (entity != null)
            {
                _context.TipoPermesso.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}