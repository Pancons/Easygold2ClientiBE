using EasyGold.API.Models.Entities;

namespace EasyGold.API.Repositories.Interfaces
{
    public interface INazioneRepository
    {
        Task<IEnumerable<DbNazioni>> GetAllAsync();
        Task<DbNazioni> GetByIdAsync(int id);
    }
}
