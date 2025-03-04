
using EasyGold.API.Models.Entities;
namespace EasyGold.API.Repositories.Interfaces
{
    public interface IRuoloRepository
    {
        Task<IEnumerable<DbRuolo>> GetAllAsync();
        Task<DbRuolo> GetByIdAsync(int id);
        Task AddAsync(DbRuolo ruolo);
        Task UpdateAsync(DbRuolo ruolo);
        Task DeleteAsync(int id);
    }
}
