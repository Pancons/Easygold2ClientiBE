using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ConfigData
{
    public interface IAliquoteIVALangService
    {
        Task<BaseListResponse<AliquoteIVALangDTO>> GetAllAsync();
        Task<AliquoteIVALangDTO> GetByIdAsync(int isonum, int id);
        Task<AliquoteIVALangDTO> AddAsync(AliquoteIVALangDTO dto);
        Task<AliquoteIVALangDTO> UpdateAsync(AliquoteIVALangDTO dto);
        Task DeleteAsync(int isonum, int id);
    }
}