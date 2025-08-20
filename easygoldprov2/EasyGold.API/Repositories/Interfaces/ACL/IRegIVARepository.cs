using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IRegIVARepository
    {
        Task<(IEnumerable<DbRegIVA> items, int total)> GetAllAsync(RegIVAListRequest request);
        Task<DbRegIVA> GetByIdAsync(int id);
        Task AddAsync(DbRegIVA entity);
        Task<DbRegIVA> UpdateAsync(DbRegIVA entity);
        Task DeleteAsync(int id);
    }
}