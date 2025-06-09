using EasyGold.Web2.Models.Cliente.Entities.ACL;
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
