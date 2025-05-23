using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Interfaces.GEO
{
    public interface IIndirizziLangRepository
    {
        Task<IEnumerable<DbIndirizziLang>> GetAllAsync();
        Task<DbIndirizziLang> GetByIdAsync(int stridISONum, int stridID);
        Task AddAsync(DbIndirizziLang entity);
        Task UpdateAsync(DbIndirizziLang entity);
        Task DeleteAsync(int stridISONum, int stridID);
    }
}