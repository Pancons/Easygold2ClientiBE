using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IAliQuoteIVAService
    {
        Task<BaseListResponse<AliQuoteIVADTO>> GetAllAsync(AliQuoteIVAListRequest filter, string language);
        Task<AliQuoteIVADTO> GetByIdAsync(int id, string language);
        Task<AliQuoteIVADTO> AddAsync(AliQuoteIVADTO dto, string language);
        Task<AliQuoteIVADTO> UpdateAsync(AliQuoteIVADTO dto, string language);
        Task DeleteAsync(int id);
    }
}