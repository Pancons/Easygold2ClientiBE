using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigProdotto
{
    public interface ITipiMetalloRepository
    {
        Task<IEnumerable<DbTipiMetallo>> GetAllAsync();
        Task<DbTipiMetallo> GetByIdAsync(int id);
        Task AddAsync(DbTipiMetallo entity);
        Task UpdateAsync(DbTipiMetallo entity);
        Task DeleteAsync(int id);
    }
}