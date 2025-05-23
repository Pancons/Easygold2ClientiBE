using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IGruppiRepository
    {
        Task<IEnumerable<DbGruppi>> GetAllAsync();
        Task<DbGruppi> GetByIdAsync(int id);
        Task AddAsync(DbGruppi entity);
        Task UpdateAsync(DbGruppi entity);
        Task DeleteAsync(int id);
    }
}