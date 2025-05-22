using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IIndirizziRepository
    {
        Task<IEnumerable<DbIndirizzi>> GetAllAsync();
        Task<DbIndirizzi> GetByIdAsync(int id);
        Task AddAsync(DbIndirizzi entity);
        Task UpdateAsync(DbIndirizzi entity);
        Task DeleteAsync(int id);
    }
}