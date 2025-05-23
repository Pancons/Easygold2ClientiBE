using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ConfigData
{
    public interface IAliquoteIVAService
    {
        Task<BaseListResponse<AliquoteIVADTO>> GetAllAsync();
        Task<AliquoteIVADTO> GetByIdAsync(int id);
        Task<AliquoteIVADTO> AddAsync(AliquoteIVADTO dto);
        Task<AliquoteIVADTO> UpdateAsync(AliquoteIVADTO dto);
        Task DeleteAsync(int id);
    }
}