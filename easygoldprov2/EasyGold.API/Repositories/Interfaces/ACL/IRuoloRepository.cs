using EasyGold.API.Models.Entities.Ruoli;
namespace EasyGold.API.Repositories.Interfaces.ACL
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
