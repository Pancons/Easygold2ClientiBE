using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface ICreditCardService
    {
        Task<BaseListResponse<CreditCardDTO>> GetAllAsync(CreditCardListRequest filter, string language);
        Task<CreditCardDTO> GetByIdAsync(int id, string language);
        Task<CreditCardDTO> AddAsync(CreditCardDTO dto, string language);
        Task<CreditCardDTO> UpdateAsync(CreditCardDTO dto, string language);
        Task DeleteAsync(int id);
    }
}