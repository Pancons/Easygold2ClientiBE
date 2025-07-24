using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.Anagrafiche
{
    public interface INegoziAltroRepository
    {
        Task<(IEnumerable<DbNegoziAltro>, int)> GetAllAsync(NegozioAltroListRequest filter);
        Task<DbNegoziAltro> GetByIdAsync(int id);
        Task AddAsync(DbNegoziAltro entity);
        Task UpdateAsync(DbNegoziAltro entity);
        Task DeleteAsync(int id);
    }
}