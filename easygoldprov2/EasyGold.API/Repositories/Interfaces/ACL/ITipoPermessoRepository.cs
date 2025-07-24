using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ITipoPermessoRepository
    {
        Task<(IEnumerable<DbTipoPermesso> items, int total)> GetAllAsync(TipoPermessoListRequest request);
        Task<DbTipoPermesso> GetByIdAsync(int id);
        Task AddAsync(DbTipoPermesso dto);
        Task<DbTipoPermesso> UpdateAsync(DbTipoPermesso dto);
        Task DeleteAsync(int id);
    }
}
