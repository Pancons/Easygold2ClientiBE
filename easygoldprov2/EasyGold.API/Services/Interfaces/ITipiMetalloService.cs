using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces
{
    public interface ITipiMetalloService
    {
        Task<BaseListResponse<TipiMetalloDTO>> GetAllAsync();
        Task<TipiMetalloDTO> GetByIdAsync(int id);
        Task<TipiMetalloDTO> AddAsync(TipiMetalloDTO dto);
        Task<TipiMetalloDTO> UpdateAsync(TipiMetalloDTO dto);
        Task DeleteAsync(int id);
    }
}