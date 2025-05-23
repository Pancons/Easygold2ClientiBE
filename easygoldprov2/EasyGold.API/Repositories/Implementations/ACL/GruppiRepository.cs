using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.ACL;

namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class GruppiRepository : IGruppiRepository
    {
        private readonly ApplicationDbContext _context;

        public GruppiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbGruppi>> GetAllAsync()
        {
            return await _context.Gruppi.AsNoTracking().ToListAsync();
        }

        public async Task<DbGruppi> GetByIdAsync(int id)
        {
            return await _context.Gruppi.AsNoTracking().FirstOrDefaultAsync(x => x.Grp_IDAuto == id);
        }

        public async Task AddAsync(DbGruppi entity)
        {
            await _context.Gruppi.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbGruppi entity)
        {
            _context.Gruppi.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Gruppi.FindAsync(id);
            if (entity != null)
            {
                _context.Gruppi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}