using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;

namespace EasyGold.API.Repositories.Implementations.Anagrafiche
{
    public class DocumentiClienteRepository : IDocumentiClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentiClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbDocumentoCliente>> GetAllAsync()
        {
            return await _context.DocumentiCliente.AsNoTracking().ToListAsync();
        }

        public async Task<DbDocumentoCliente> GetByIdAsync(int id)
        {
            return await _context.DocumentiCliente.AsNoTracking()
                                                  .FirstOrDefaultAsync(x => x.Doc_IdAuto == id);
        }

        public async Task AddAsync(DbDocumentoCliente entity)
        {
            await _context.DocumentiCliente.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbDocumentoCliente entity)
        {
            _context.DocumentiCliente.Update(entity);
            await _context.SaveChangesAsync();
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
