using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ConfigProdotto
{
    public interface ITipiMetalloLangService
    {
        Task<BaseListResponse<TipiMetalloLangDTO>> GetAllAsync();
        Task<TipiMetalloLangDTO> GetByIdAsync(int timidISONum, int timidID);
        Task<TipiMetalloLangDTO> AddAsync(TipiMetalloLangDTO dto);
        Task<TipiMetalloLangDTO> UpdateAsync(TipiMetalloLangDTO dto);
        Task DeleteAsync(int timidISONum, int timidID);
    }
}