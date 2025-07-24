using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IStampePostazioniRepository
    {
        Task<(IEnumerable<DbStampePostazioni> items, int total)> GetAllAsync(StampePostazioniListRequest request);
        Task<DbStampePostazioni> GetByIdAsync(int id);
        Task AddAsync(DbStampePostazioni dto);
        Task<DbStampePostazioni> UpdateAsync(DbStampePostazioni dto);
        Task DeleteAsync(int id);
    }
}
