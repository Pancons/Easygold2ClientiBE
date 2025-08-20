using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface INumeriRegIVARepository
    {
        Task<(IEnumerable<DbNumeriRegIVA> items, int total)> GetAllAsync(NumeriRegIVAListRequest request);
        Task<DbNumeriRegIVA> GetByIdAsync(int id);
        Task AddAsync(DbNumeriRegIVA entity);
        Task UpdateAsync(DbNumeriRegIVA entity);
        Task DeleteAsync(int id);
    }
}
