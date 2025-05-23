using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Entities.Config;

namespace EasyGold.API.Repositories.Interfaces.ConfigProgramma
{
    public interface IConfigRepository
    {
        Task<IEnumerable<DbConfig>> GetAllAsync();
        Task<DbConfig> GetByIdAsync(int id);
        Task AddAsync(DbConfig entity);
        Task UpdateAsync(DbConfig entity);
        Task DeleteAsync(int id);
    }
}