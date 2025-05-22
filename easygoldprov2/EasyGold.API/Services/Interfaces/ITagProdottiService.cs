using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;

namespace EasyGold.API.Services.Interfaces
{
    public interface ITagProdottiService
    {
        Task<BaseListResponse<TagProdottiDTO>> GetAllAsync(BaseListRequest request);
        Task<TagProdottiDTO> GetByIdAsync(int id);
        Task<TagProdottiDTO> AddAsync(TagProdottiDTO dto);
        Task<TagProdottiDTO> UpdateAsync(TagProdottiDTO dto);
        Task DeleteAsync(int id);
    }
}