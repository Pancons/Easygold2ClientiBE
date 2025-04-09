using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGold.API.Infrastructure;
using EasyGold.API.Models.Entities;
using EasyGold.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyGold.API.Repositories.Implementations
{
    public class ModuloClienteRepository : IModuloClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuloClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DbModuloCliente>> GetAllAsync()
        {
            return await _context.ModuloClienti
                .Include(mc => mc.Cliente)
                .Include(mc => mc.Modulo)
                .ToListAsync();
        }

        public async Task<DbModuloCliente> GetByIdAsync(int id)
        {
            return await _context.ModuloClienti
                .Include(mc => mc.Cliente)
                .Include(mc => mc.Modulo)
                .FirstOrDefaultAsync(mc => mc.Mdc_IDAuto == id);
        }

        public async Task<IEnumerable<Tuple<DbModuloEasygold, DbModuloCliente>>> GetByClienteIdAsync(int clienteId)
        {
            var moduli = await _context.ModuloClienti
                .Where(mc => mc.Mdc_IDCliente == clienteId)
                .Join(_context.ModuloEasygold,
                    mc => mc.Mdc_IDModulo,
                    me => me.Mde_IDAuto,
                    (mc, me) => new Tuple<DbModuloEasygold, DbModuloCliente>(me, mc))
                .ToListAsync();


            if (moduli.Count() > 0)
            {
                var moduliSelezionati = moduli.Select(mc => mc.Item1.Mde_IDAuto).ToList();

                var moduliNonSelezionati = await _context.ModuloEasygold
                    .Where(me => !moduliSelezionati.Contains(me.Mde_IDAuto))
                    .Select(me => new Tuple<DbModuloEasygold, DbModuloCliente>(me, new DbModuloCliente()))
                    .ToListAsync();

                moduli.AddRange(moduliNonSelezionati);
            }
            else
            {
                var moduliNonSelezionati = await _context.ModuloEasygold
                    .Select(me => new Tuple<DbModuloEasygold, DbModuloCliente>(me, new DbModuloCliente()))
                    .ToListAsync();

                moduli.AddRange(moduliNonSelezionati);
            }

            return moduli;
        }

        public async Task<IEnumerable<DbModuloCliente>> GetByModuloIdAsync(int moduloId)
        {
            return await _context.ModuloClienti
                .Where(mc => mc.Mdc_IDModulo == moduloId)
                .Include(mc => mc.Cliente)
                .ToListAsync();
        }

        public async Task<DbModuloCliente> GetByClienteAndModuloAsync(int clienteId, int moduloId)
        {
            return await _context.ModuloClienti
                .FirstOrDefaultAsync(mc => mc.Mdc_IDCliente == clienteId && mc.Mdc_IDModulo == moduloId);
        }

        public async Task AddAsync(DbModuloCliente moduloCliente)
        {
            await _context.ModuloClienti.AddAsync(moduloCliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DbModuloCliente moduloCliente)
        {
            var existing = await _context.ModuloClienti.FindAsync(moduloCliente.Mdc_IDAuto);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(moduloCliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var moduloCliente = await _context.ModuloClienti.FindAsync(id);
            if (moduloCliente != null)
            {
                _context.ModuloClienti.Remove(moduloCliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByClienteAsync(int clienteId)
        {
            var moduliCliente = await _context.ModuloClienti
                .Where(mc => mc.Mdc_IDCliente == clienteId)
                .ToListAsync();

            if (moduliCliente.Any())
            {
                _context.ModuloClienti.RemoveRange(moduliCliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
