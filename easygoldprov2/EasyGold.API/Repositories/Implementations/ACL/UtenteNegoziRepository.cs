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
    public class UtenteNegoziRepository : IUtenteNegoziRepository
    {
        private readonly ApplicationDbContext _context;

        public UtenteNegoziRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbUtenteNegozi> items, int total)> GetAllAsync(UtenteNegoziListRequest request)
        {
            var query = _context.UtentiNegozi.AsQueryable();
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            return (items, total);
        }

        public async Task<DbUtenteNegozi> GetByIdAsync(int id)
        {
            var entity = await _context.UtentiNegozi.FindAsync(id);
            return entity == null ? null : new DbUtenteNegozi
            {
                Utn_IDAuto = entity.Utn_IDAuto,
                Utn_IDUtente = entity.Utn_IDUtente,
                Utn_IDNegozio = entity.Utn_IDNegozio,
                Utn_Default = entity.Utn_Default,
                Utn_Annullato = entity.Utn_Annullato
            };
        }

        public async Task AddAsync(DbUtenteNegozi entity)
        {
            await _context.UtentiNegozi.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbUtenteNegozi> UpdateAsync(DbUtenteNegozi entity)
        {
          
            _context.UtentiNegozi.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UtentiNegozi.FindAsync(id);
            if (entity != null)
            {
                _context.UtentiNegozi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}