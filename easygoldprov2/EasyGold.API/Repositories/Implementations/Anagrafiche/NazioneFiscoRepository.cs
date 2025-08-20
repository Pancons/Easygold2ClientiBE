using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class NazioneFiscoRepository : INazioneFiscoRepository
    {
        private readonly ApplicationDbContext _context;

        public NazioneFiscoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DbNazioneFisco> items, int total)> GetAllAsync(NazioneFiscoListRequest request)
        {
            var query = _context.NazioneFisco.AsQueryable();
            
            // Esegui filtro e paginazione se richiesto
            int total = await query.CountAsync();
            var items = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();

            return (items, total);
        }

        public async Task<DbNazioneFisco> GetByIdAsync(int id)
        {
            return await _context.NazioneFisco.FindAsync(id);
        }

        public async Task AddAsync(DbNazioneFisco entity)
        {
            await _context.NazioneFisco.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DbNazioneFisco> UpdateAsync(DbNazioneFisco entity)
        {
            _context.NazioneFisco.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.NazioneFisco.FindAsync(id);
            if (entity != null)
            {
                _context.NazioneFisco.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}