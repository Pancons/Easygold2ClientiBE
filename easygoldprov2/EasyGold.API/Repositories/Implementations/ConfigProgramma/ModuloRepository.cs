using EasyGold.API.Infrastructure;
using EasyGold.Web2.Models.Cliente.Entities.ConfigProgramma;
using EasyGold.API.Repositories.Interfaces.ConfigProgramma;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations.ConfigProgramma
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbModuloEasygold>> GetAllAsync()
        {
            return await _context.ModuloEasygold.ToListAsync();
        }

        public async Task<DbModuloEasygold> GetByIdAsync(int id)
        {
            return await _context.ModuloEasygold.FindAsync(id);
        }

        public async Task AddAsync(DbModuloEasygold modulo)
        {
            await _context.ModuloEasygold.AddAsync(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbModuloEasygold modulo)
        {
            _context.ModuloEasygold.Update(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var modulo = await GetByIdAsync(id);
            if (modulo != null)
            {
                _context.ModuloEasygold.Remove(modulo);
                await _context.SaveChangesAsync();
            }
        }



    }
}
