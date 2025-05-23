using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IUtentiService
    {
        Task<BaseListResponse<UtentiDTO>> GetAllAsync();
        Task<UtentiDTO> GetByIdAsync(int id);
        Task<UtentiDTO> AddAsync(UtentiDTO dto);
        Task<UtentiDTO> UpdateAsync(UtentiDTO dto);
        Task DeleteAsync(int id);
    }
}