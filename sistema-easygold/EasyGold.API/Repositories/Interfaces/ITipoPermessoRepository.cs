using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Repositories.Interfaces
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
