using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IGruppiService
    {
        Task<BaseListResponse<GruppiDTO>> GetAllAsync();
        Task<GruppiDTO> GetByIdAsync(int id);
        Task<GruppiDTO> AddAsync(GruppiDTO dto);
        Task<GruppiDTO> UpdateAsync(GruppiDTO dto);
        Task DeleteAsync(int id);
    }
}