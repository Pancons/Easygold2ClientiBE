using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;


namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IListiniTabellaRepository
    {
        Task<(IEnumerable<DbListiniTabella>, int total)> GetAllAsync(ListiniTabellaListRequest filter, string language);
        Task<DbListiniTabella> GetByIdAsync(int id, string language);
        Task AddAsync(DbListiniTabella entity, string language);
        Task UpdateAsync(DbListiniTabella entity, string language);
        Task DeleteAsync(int id);
    }
}