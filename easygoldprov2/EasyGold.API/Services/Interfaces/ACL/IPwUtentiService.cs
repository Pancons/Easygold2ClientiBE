using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IPwUtentiService
    {
        Task<BaseListResponse<PwUtentiDTO>> GetAllAsync(PwUtentiListRequest filter);
        Task<PwUtentiDTO> GetByIdAsync(int id);
        Task<PwUtentiDTO> AddAsync(PwUtentiDTO dto);
        Task<PwUtentiDTO> UpdateAsync(PwUtentiDTO dto);
        Task DeleteAsync(int id);
    }
}