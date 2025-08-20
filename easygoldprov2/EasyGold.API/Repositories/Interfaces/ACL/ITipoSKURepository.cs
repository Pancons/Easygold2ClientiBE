using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ITipoSKURepository
    {
        Task<(IEnumerable<DbTipoSKU> items, int total)> GetAllAsync(TipoSKUListRequest request);
        Task<DbTipoSKU> GetByIdAsync(int id);
        Task AddAsync(DbTipoSKU entity);
        Task<DbTipoSKU> UpdateAsync(DbTipoSKU entity);
        Task DeleteAsync(int id);
    }
}