using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Implementations
{
    public class UtenteNegoziRepository : IUtenteNegoziRepository
    {
        private readonly ApplicationDbContext _context;

        public UtenteNegoziRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbUtenteNegozi>> GetAllAsync()
        {
            return await _context.UtenteNegozi.AsNoTracking().ToListAsync();
        }

        public async Task<DbUtenteNegozi> GetByIdAsync(int id)
        {
            return await _context.UtenteNegozi.AsNoTracking().FirstOrDefaultAsync(x => x.Utn_ID == id);
        }

        public async Task AddAsync(DbUtenteNegozi entity)
        {
            await _context.UtenteNegozi.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbUtenteNegozi entity)
        {
            _context.UtenteNegozi.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UtenteNegozi.FindAsync(id);
            if (entity != null)
            {
                _context.UtenteNegozi.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}