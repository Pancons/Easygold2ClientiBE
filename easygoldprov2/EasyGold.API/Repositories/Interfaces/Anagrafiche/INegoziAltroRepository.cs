using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.Anagrafiche
{
    public interface INegoziAltroRepository
    {
        Task<IEnumerable<DbNegoziAltro>> GetAllAsync();
        Task<DbNegoziAltro> GetByIdAsync(int id);
        Task AddAsync(DbNegoziAltro entity);
        Task UpdateAsync(DbNegoziAltro entity);
        Task DeleteAsync(int id);
    }
}