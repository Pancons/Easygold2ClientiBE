using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface ICauOrdinamentoRepository
    {
        Task<(IEnumerable<DbCauOrdinamento>, int total)> GetAllAsync(CauOrdinamentoListRequest filter);
        Task<DbCauOrdinamento> GetByIdAsync(int id);
        Task AddAsync(DbCauOrdinamento entity);
        Task UpdateAsync(DbCauOrdinamento entity);
        Task DeleteAsync(int id);
    }
}