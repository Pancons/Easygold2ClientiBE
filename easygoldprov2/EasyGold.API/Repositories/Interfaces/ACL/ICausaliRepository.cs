using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ICausaliRepository
    {
        Task<(IEnumerable<DbCausali>, int total)> GetAllAsync(CausaliListRequest filter, string language);
        Task<DbCausali> GetByIdAsync(int id, string language);
        Task AddAsync(DbCausali entity, string language);
        Task UpdateAsync(DbCausali entity, string language);
        Task DeleteAsync(int id);
    }
}