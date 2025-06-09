using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ConfigProgramma;

namespace EasyGold.API.Repositories.Interfaces.ConfigProgramma
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