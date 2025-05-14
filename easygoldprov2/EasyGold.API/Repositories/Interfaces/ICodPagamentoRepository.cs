using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface ICodPagamentoRepository
    {
        Task<IEnumerable<DbCodPagamento>> GetAllAsync();
        Task<DbCodPagamento> GetByIdAsync(int id);
        Task AddAsync(DbCodPagamento entity);
        Task UpdateAsync(DbCodPagamento entity);
        Task DeleteAsync(int id);
    }
}