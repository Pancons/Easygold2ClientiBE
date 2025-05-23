using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface ICausaliClienteRepository
    {
        Task<IEnumerable<DbCausaliCliente>> GetAllAsync();
        Task<DbCausaliCliente> GetByIdAsync(int id);
        Task AddAsync(DbCausaliCliente entity);
        Task UpdateAsync(DbCausaliCliente entity);
        Task DeleteAsync(int id);
    }
}