using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IIdiomiSceltiRepository
    {
        Task<(IEnumerable<DbIdiomiScelti>, int total)> GetAllAsync(IdiomiSceltiListRequest filter);
        Task<DbIdiomiScelti> GetByIdAsync(int id);
        Task AddAsync(DbIdiomiScelti entity);
        Task UpdateAsync(DbIdiomiScelti entity);
        Task DeleteAsync(int id);
    }
}