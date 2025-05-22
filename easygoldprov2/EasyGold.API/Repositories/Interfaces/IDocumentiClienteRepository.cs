using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface IDocumentiClienteRepository
    {
        Task<IEnumerable<DbDocumentiCliente>> GetAllAsync();
        Task<DbDocumentiCliente> GetByIdAsync(int id);
        Task AddAsync(DbDocumentiCliente entity);
        Task UpdateAsync(DbDocumentiCliente entity);
        Task DeleteAsync(int id);
    }
}