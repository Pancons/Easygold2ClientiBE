using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IUtenteNegoziRepository
    {
        Task<(IEnumerable<DbUtenteNegozi> items, int total)> GetAllAsync(UtenteNegoziListRequest request);
        Task<DbUtenteNegozi> GetByIdAsync(int id);
        Task AddAsync(DbUtenteNegozi dto);
        Task<DbUtenteNegozi> UpdateAsync(DbUtenteNegozi dto);
        Task DeleteAsync(int id);
    }
}