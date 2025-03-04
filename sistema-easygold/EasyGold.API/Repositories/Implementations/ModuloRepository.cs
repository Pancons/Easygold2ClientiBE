using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
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

        public async Task<DbModuloCliente> GetByIdAsync(int id)
        {
            return await _context.ModuloClienti.FindAsync(id);
        }

        public async Task AddAsync(DbModuloCliente modulo)
        {
            await _context.ModuloClienti.AddAsync(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbModuloCliente modulo)
        {
            _context.ModuloClienti.Update(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var modulo = await GetByIdAsync(id);
            if (modulo != null)
            {
                _context.ModuloClienti.Remove(modulo);
                await _context.SaveChangesAsync();
            }
        }



    }
}
