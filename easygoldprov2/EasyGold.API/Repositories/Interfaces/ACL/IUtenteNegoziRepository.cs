using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IUtenteNegoziRepository
    {
        Task<IEnumerable<DbUtenteNegozi>> GetAllAsync();
        Task<DbUtenteNegozi> GetByIdAsync(int id);
        Task AddAsync(DbUtenteNegozi entity);
        Task UpdateAsync(DbUtenteNegozi entity);
        Task DeleteAsync(int id);
    }
}