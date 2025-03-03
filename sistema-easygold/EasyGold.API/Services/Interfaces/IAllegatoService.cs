using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Allegati;

namespace EasyGold.API.Services.Interfaces
{
    public interface IAllegatoService
    {
        Task<IEnumerable<AllegatoDTO>> GetAllAsync();
        Task<AllegatoDTO> GetByIdAsync(int id);
        Task AddAsync(AllegatoDTO allegato);
        Task UpdateAsync(AllegatoDTO allegato);
        Task DeleteAsync(int id);
    }

}

