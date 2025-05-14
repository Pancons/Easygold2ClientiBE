using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Infrastructure;

namespace EasyGold.API.Repositories.Implementations
{
    public class DocumentiClienteRepository : IDocumentiClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentiClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbDocumentiCliente>> GetAllAsync()
        {
            return await _context.DocumentiCliente.AsNoTracking().ToListAsync();
        }

        public async Task<DbDocumentiCliente> GetByIdAsync(int id)
        {
            return await _context.DocumentiCliente.AsNoTracking().FirstOrDefaultAsync(x => x.Doc_IDAuto == id);
        }

        public async Task AddAsync(DbDocumentiCliente entity)
        {
            await _context.DocumentiCliente.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbDocumentiCliente entity)
        {
            var existing = await _context.DocumentiCliente.FindAsync(entity.Doc_IDAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DocumentiCliente.FindAsync(id);
            if (entity != null)
            {
                _context.DocumentiCliente.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}