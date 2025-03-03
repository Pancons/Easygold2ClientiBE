using EasyGold.API.Models.Clients;
using EasyGold.API.Models.Entities;


namespace EasyGold.API.Repositories.Interfaces
{
    public interface IAllegatoRepository
    {
        Task<IEnumerable<DbAllegato>> GetAllAsync();
        Task<DbAllegato> GetByIdAsync(int id);
        Task AddAsync(DbAllegato allegato);
        Task UpdateAsync(DbAllegato allegato);
        Task DeleteAsync(int id);

        
    }
}
