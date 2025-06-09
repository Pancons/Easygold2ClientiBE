using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Comune.ACL;

namespace EasyGold.API.Services.Interfaces.GEO
{
    public interface IIndirizziLangService
    {
        Task<BaseListResponse<IndirizziLangDTO>> GetAllAsync();
        Task<IndirizziLangDTO> GetByIdAsync(int stridISONum, int stridID);
        Task<IndirizziLangDTO> AddAsync(IndirizziLangDTO dto);
        Task<IndirizziLangDTO> UpdateAsync(IndirizziLangDTO dto);
        Task DeleteAsync(int stridISONum, int stridID);
    }
}