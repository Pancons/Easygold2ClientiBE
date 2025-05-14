using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.DTO;

namespace EasyGold.API.Services.Interfaces
{
    public interface ICreditCardService
    {
        Task<BaseListResponse<CreditCardDTO>> GetAllAsync(BaseListRequest request);
        Task<CreditCardDTO> GetByIdAsync(int id);
        Task<CreditCardDTO> AddAsync(CreditCardDTO dto);
        Task<CreditCardDTO> UpdateAsync(CreditCardDTO dto);
        Task DeleteAsync(int id);
    }
}