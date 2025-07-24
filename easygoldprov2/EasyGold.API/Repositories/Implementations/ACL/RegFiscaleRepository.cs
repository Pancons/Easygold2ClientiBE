using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class RegFiscaleRepository : IRegFiscaleRepository
    {
        private readonly ApplicationDbContext _context;

        public RegFiscaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbRegFiscale> lista, int totale)> GetAllAsync(RegFiscaleListRequest filter)
        {
            var query = _context.RegFiscali.AsQueryable();

            int total = await query.CountAsync();
            var lista = await query.Skip(filter.Offset).Take(filter.Limit).ToListAsync();

            return (lista, total);
        }

        public async Task<DbRegFiscale> GetByIdAsync(int id)
        {
            return await _context.RegFiscali
                .Include(rf => rf.Negozio)
                .FirstOrDefaultAsync(r => r.Rfi_IDAuto == id);
        }

        public async Task AddAsync(DbRegFiscale entity)
        {
            await _context.RegFiscali.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbRegFiscale entity)
        {
            _context.RegFiscali.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegFiscali.FindAsync(id);
            if (entity != null)
            {
                _context.RegFiscali.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
