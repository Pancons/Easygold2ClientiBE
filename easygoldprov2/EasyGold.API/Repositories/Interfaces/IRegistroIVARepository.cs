using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IRegistroIVARepository
    {
        Task<IEnumerable<DbRegistroIVA>> GetAllAsync();
        Task<DbRegistroIVA> GetByIdAsync(int id);
        Task AddAsync(DbRegistroIVA registro);
        Task UpdateAsync(DbRegistroIVA registro);
        Task DeleteAsync(int id);
    }
}