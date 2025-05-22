using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface INegoziRepository
    {
        Task<IEnumerable<DbNegozi>> GetAllAsync();
        Task<DbNegozi> GetByIdAsync(int id);
        Task AddAsync(DbNegozi entity);
        Task UpdateAsync(DbNegozi entity);
        Task DeleteAsync(int id);
    }
}