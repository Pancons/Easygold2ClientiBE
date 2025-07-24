using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface ILettorePostazioniRepository
    {
        Task<(IEnumerable<DbLettorePostazioni>, int total)> GetAllAsync(LettorePostazioniListRequest filter);
        Task<DbLettorePostazioni> GetByIdAsync(int id);
        Task AddAsync(DbLettorePostazioni entity);
        Task UpdateAsync(DbLettorePostazioni entity);
        Task DeleteAsync(int id);
    }
}