using EasyGold.API.Models.Entities.Moduli;

namespace EasyGold.API.Repositories.Interfaces.ConfigProgramma
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
