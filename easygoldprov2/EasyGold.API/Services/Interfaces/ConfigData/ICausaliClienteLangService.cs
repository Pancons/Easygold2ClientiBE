using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ConfigData
{
    public interface ICausaliClienteLangService
    {
        Task<BaseListResponse<CausaliClienteLangDTO>> GetAllAsync();
        Task<CausaliClienteLangDTO> GetByIdAsync(int isonum, int id);
        Task<CausaliClienteLangDTO> AddAsync(CausaliClienteLangDTO dto);
        Task<CausaliClienteLangDTO> UpdateAsync(CausaliClienteLangDTO dto);
        Task DeleteAsync(int isonum, int id);
    }
}