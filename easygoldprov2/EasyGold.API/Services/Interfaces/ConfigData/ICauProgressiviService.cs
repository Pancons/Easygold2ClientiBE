using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Comune.ACL;

namespace EasyGold.API.Services.Interfaces.ConfigData
{
    public interface ICauProgressiviService
    {
        Task<BaseListResponse<CauProgressiviDTO>> GetAllAsync();
        Task<CauProgressiviDTO> GetByIdAsync(int id);
        Task<CauProgressiviDTO> AddAsync(CauProgressiviDTO dto);
        Task<CauProgressiviDTO> UpdateAsync(CauProgressiviDTO dto);
        Task DeleteAsync(int id);
    }
}