using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IStatoRegioniLangRepository
    {
        Task<IEnumerable<DbStatoRegioniLang>> GetAllAsync();
        Task<DbStatoRegioniLang> GetByIdAsync(int stridISONum, int stridID);
        Task AddAsync(DbStatoRegioniLang entity);
        Task UpdateAsync(DbStatoRegioniLang entity);
        Task DeleteAsync(int stridISONum, int stridID);
    }
}