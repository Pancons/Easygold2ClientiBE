using EasyGold.API.Infrastructure;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using Microsoft.EntityFrameworkCore;



namespace EasyGold.API.Repositories.Implementations.ACL
{
    public class RuoloRepository : IRuoloRepository
    {
        private readonly ApplicationDbContext _context;

        public RuoloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbRuolo>> GetAllAsync()
        {
            return await _context.Ruoli.ToListAsync();
        }

        public async Task<DbRuolo> GetByIdAsync(int id)
        {
            return await _context.Ruoli.FindAsync(id);
        }

        public async Task AddAsync(DbRuolo ruolo)
        {
            await _context.Ruoli.AddAsync(ruolo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbRuolo ruolo)
        {
            _context.Ruoli.Update(ruolo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ruolo = await GetByIdAsync(id);
            if (ruolo != null)
            {
                _context.Ruoli.Remove(ruolo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
