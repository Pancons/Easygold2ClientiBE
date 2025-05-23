using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface IAliquoteIVALangRepository
    {
        Task<IEnumerable<DbAliquoteIVALang>> GetAllAsync();
        Task<DbAliquoteIVALang> GetByIdAsync(int isonum, int id);
        Task AddAsync(DbAliquoteIVALang entity);
        Task UpdateAsync(DbAliquoteIVALang entity);
        Task DeleteAsync(int isonum, int id);
    }
}