using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IPwUtentiService
    {
        Task<BaseListResponse<PwUtentiDTO>> GetAllAsync();
        Task<PwUtentiDTO> GetByIdAsync(int id);
        Task<PwUtentiDTO> AddAsync(PwUtentiDTO dto);
        Task<PwUtentiDTO> UpdateAsync(PwUtentiDTO dto);
        Task DeleteAsync(int id);
    }
}