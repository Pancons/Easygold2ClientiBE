using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IPwUtentiRepository
    {
        Task<IEnumerable<DbPwUtenti>> GetAllAsync();
        Task<DbPwUtenti> GetByIdAsync(int id);
        Task AddAsync(DbPwUtenti entity);
        Task UpdateAsync(DbPwUtenti entity);
        Task DeleteAsync(int id);
    }
}