using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ITestataPostazioniRepository
    {
        Task<(IEnumerable<DbTestataPostazioni> items, int total)> GetAllAsync(TestataPostazioniListRequest request);
        Task<DbTestataPostazioni> GetByIdAsync(int id);
        Task AddAsync(DbTestataPostazioni dto);
        Task<DbTestataPostazioni> UpdateAsync(DbTestataPostazioni dto);
        Task DeleteAsync(int id);
    }
}
