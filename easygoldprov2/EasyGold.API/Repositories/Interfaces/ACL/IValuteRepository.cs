using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IValuteRepository
    {
        Task<(IEnumerable<DbValute>, int total)> GetAllAsync(ValuteListRequest filter, string language);
        Task<DbValute> GetByIdAsync(int id, string language);
        Task AddAsync(DbValute entity, string language);
        Task UpdateAsync(DbValute entity, string language);
        Task DeleteAsync(int id);
    }
}