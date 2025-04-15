using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IModuloClienteRepository
    {
        Task<IEnumerable<DbModuloCliente>> GetAllAsync();
        Task<DbModuloCliente> GetByIdAsync(int id);
        Task<IEnumerable<Tuple<DbModuloEasygold, DbModuloCliente>>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<DbModuloCliente>> GetByModuloIdAsync(int moduloId);
        Task<DbModuloCliente> GetByClienteAndModuloAsync(int clienteId, int moduloId);
        Task AddAsync(DbModuloCliente moduloCliente);
        Task UpdateAsync(DbModuloCliente moduloCliente);
        Task DeleteAsync(int id);
        Task DeleteByClienteAsync(int clienteId);
    }
}
