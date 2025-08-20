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
    public interface IValuteService
    {
        Task<BaseListResponse<ValuteDTO>> GetAllAsync(ValuteListRequest filter, string language);
        Task<ValuteDTO> GetByIdAsync(int id, string language);
        Task<ValuteDTO> AddAsync(ValuteDTO dto, string language);
        Task<ValuteDTO> UpdateAsync(ValuteDTO dto, string language);
        Task DeleteAsync(int id);
    }
}