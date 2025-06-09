using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.Contabilita;

namespace EasyGold.API.Repositories.Interfaces.Contabilita
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