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
    public interface IIdiomiEasyGoldRepository
    {
        Task<(IEnumerable<DbIdiomiEasyGold>, int total)> GetAllAsync(IdiomiEasyGoldListRequest filter);
        Task<DbIdiomiEasyGold> GetByIdAsync(int id);
        Task AddAsync(DbIdiomiEasyGold entity);
        Task UpdateAsync(DbIdiomiEasyGold entity);
        Task DeleteAsync(int id);
    }
}