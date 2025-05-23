using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Comune.Entities;

namespace EasyGold.API.Repositories.Interfaces.ConfigData
{
    public interface ICausaliComuneRepository
    {
        Task<IEnumerable<DbCausaliComune>> GetAllAsync();
        Task<DbCausaliComune> GetByIdAsync(int id);
        Task AddAsync(DbCausaliComune entity);
        Task UpdateAsync(DbCausaliComune entity);
        Task DeleteAsync(int id);
    }
}