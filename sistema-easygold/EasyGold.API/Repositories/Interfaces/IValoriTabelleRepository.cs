using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Utenti;
namespace EasyGold.API.Repositories.Interfaces
{

    public interface IValoriTabelleRepository
    {
        Task<IEnumerable<DbValoriTabelle>> FindByItemTypeAsync(string itemType);
        Task<DbValoriTabelle> GetByIdAsync(int id);
        Task InsertAsync(DbValoriTabelle entity);
        Task UpdateAsync(DbValoriTabelle entity);
    }
}