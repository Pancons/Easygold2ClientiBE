using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ITipoPwRepository
    {
        Task<(IEnumerable<DbTipoPw> items, int total)> GetAllAsync(TipoPwListRequest request);
        Task<DbTipoPw> GetByIdAsync(int id);
        Task AddAsync(DbTipoPw dto);
        Task<DbTipoPw> UpdateAsync(DbTipoPw dto);
        Task DeleteAsync(int id);
    }
}
