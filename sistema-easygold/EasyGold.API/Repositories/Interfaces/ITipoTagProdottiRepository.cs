using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface ITipoTagProdottiRepository
    {
        Task<(IEnumerable<DbTipoTagProdotti>, int total)> GetAllAsync(TipoTagProdottiListRequest filter);
        Task<DbTipoTagProdotti> GetByIdAsync(int id);
        Task AddAsync(DbTipoTagProdotti entity);
        Task UpdateAsync(DbTipoTagProdotti entity);
        Task DeleteAsync(int id);
    }
}