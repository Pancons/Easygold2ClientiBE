using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;

namespace EasyGold.API.Services.Interfaces
{
    public interface IGruppiService
    {
        Task<BaseListResponse<GruppiDTO>> GetAllAsync(BaseListRequest request);
        Task<GruppiDTO> GetByIdAsync(int id);
        Task<GruppiDTO> AddAsync(GruppiDTO dto);
        Task<GruppiDTO> UpdateAsync(GruppiDTO dto);
        Task DeleteAsync(int id);
    }
}