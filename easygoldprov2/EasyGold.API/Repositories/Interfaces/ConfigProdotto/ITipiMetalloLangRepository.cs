using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigProdotto
{
    public interface ITipiMetalloLangRepository
    {
        Task<IEnumerable<DbTipiMetalloLang>> GetAllAsync();
        Task<DbTipiMetalloLang> GetByIdAsync(int timidISONum, int timidID);
        Task AddAsync(DbTipiMetalloLang entity);
        Task UpdateAsync(DbTipiMetalloLang entity);
        Task DeleteAsync(int timidISONum, int timidID);
    }
}