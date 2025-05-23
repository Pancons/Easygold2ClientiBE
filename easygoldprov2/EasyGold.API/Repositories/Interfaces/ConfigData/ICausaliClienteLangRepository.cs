using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface ICausaliClienteLangRepository
    {
        Task<IEnumerable<DbCausaliClienteLang>> GetAllAsync();
        Task<DbCausaliClienteLang> GetByIdAsync(int isonum, int id);
        Task AddAsync(DbCausaliClienteLang entity);
        Task UpdateAsync(DbCausaliClienteLang entity);
        Task DeleteAsync(int isonum, int id);
    }
}