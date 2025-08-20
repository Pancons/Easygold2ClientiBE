using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IConfigRepository
    {
        Task<(IEnumerable<DbConfig>, int)> GetAllAsync(ConfigListRequest filter, string language);
        Task<DbConfig> GetByIdAsync(int id, string language);
        Task AddAsync(DbConfig entity, string language);
        Task UpdateAsync(DbConfig entity, string language);
        Task DeleteAsync(int id);
    }
}