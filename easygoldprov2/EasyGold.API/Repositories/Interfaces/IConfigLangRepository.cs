using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities.Config;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IConfigLangRepository
    {
        Task<IEnumerable<DbConfigLang>> GetAllAsync();
        Task<DbConfigLang> GetByIdAsync(int isoNum, int id);
        Task AddAsync(DbConfigLang entity);
        Task UpdateAsync(DbConfigLang entity);
        Task DeleteAsync(int isoNum, int id);
    }
}