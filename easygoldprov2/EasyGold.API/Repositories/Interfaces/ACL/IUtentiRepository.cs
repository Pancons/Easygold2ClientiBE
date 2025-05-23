using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IUtentiRepository
    {
        Task<IEnumerable<DbUtenti>> GetAllAsync();
        Task<DbUtenti> GetByIdAsync(int id);
        Task AddAsync(DbUtenti entity);
        Task UpdateAsync(DbUtenti entity);
        Task DeleteAsync(int id);
    }
}