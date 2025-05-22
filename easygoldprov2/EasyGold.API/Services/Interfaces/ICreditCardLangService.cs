using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;

namespace EasyGold.API.Services.Interfaces
{
    public interface ICreditCardLangService
    {
        Task<BaseListResponse<CreditCardLangDTO>> GetAllAsync(BaseListRequest request);
        Task<CreditCardLangDTO> GetByIdAsync(int isoNum, int id);
        Task<CreditCardLangDTO> AddAsync(CreditCardLangDTO dto);
        Task<CreditCardLangDTO> UpdateAsync(CreditCardLangDTO dto);
        Task DeleteAsync(int isoNum, int id);
    }
}