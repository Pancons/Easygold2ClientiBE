using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IModuloRepository
    {
        Task<IEnumerable<DbModuloEasygold>> GetAllAsync();

        
        Task<DbModuloCliente> GetByIdAsync(int id);
        Task AddAsync(DbModuloCliente modulo);
        Task UpdateAsync(DbModuloCliente modulo);
        Task DeleteAsync(int id);
    }
}
