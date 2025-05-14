using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<DbCreditCard>> GetAllAsync();
        Task<DbCreditCard> GetByIdAsync(int id);
        Task AddAsync(DbCreditCard entity);
        Task UpdateAsync(DbCreditCard entity);
        Task DeleteAsync(int id);
    }
}