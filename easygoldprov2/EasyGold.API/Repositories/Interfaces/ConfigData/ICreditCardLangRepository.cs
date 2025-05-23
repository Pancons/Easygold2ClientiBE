using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface ICreditCardLangRepository
    {
        Task<IEnumerable<DbCreditCardLang>> GetAllAsync();
        Task<DbCreditCardLang> GetByIdAsync(int isoNum, int id);
        Task AddAsync(DbCreditCardLang entity);
        Task UpdateAsync(DbCreditCardLang entity);
        Task DeleteAsync(int isoNum, int id);
    }
}