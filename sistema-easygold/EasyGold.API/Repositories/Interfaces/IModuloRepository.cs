using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IModuloRepository
    {
        Task<IEnumerable<DbModuloEasygold>> GetAllAsync();

        
        Task<DbModuloEasygold> GetByIdAsync(int id);
        Task AddAsync(DbModuloEasygold modulo);
        Task UpdateAsync(DbModuloEasygold modulo);
        Task DeleteAsync(int id);
    }
}
