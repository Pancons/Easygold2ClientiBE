using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyGold.Web2.Models.Cliente.Entities;
using EasyGold.API.Repositories.Interfaces.ConfigData;

namespace EasyGold.API.Repositories.Implementations.ConfigData
{
    public class CausaliClienteRepository : ICausaliClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public CausaliClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbCausaliCliente>> GetAllAsync()
        {
            return await _context.CausaliCliente.AsNoTracking().ToListAsync();
        }

        public async Task<DbCausaliCliente> GetByIdAsync(int id)
        {
            return await _context.CausaliCliente.AsNoTracking().FirstOrDefaultAsync(x => x.Cal_IDAuto == id);
        }

        public async Task AddAsync(DbCausaliCliente entity)
        {
            await _context.CausaliCliente.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbCausaliCliente entity)
        {
            _context.CausaliCliente.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CausaliCliente.FindAsync(id);
            if (entity != null)
            {
                _context.CausaliCliente.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}