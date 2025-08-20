using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;
using EasyGold.Web2.Models.Comune.ACL;
using EasyGold.Web2.Models.Comune.Entities;
using EasyGold.Web2.Models.Comune.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities.ACL;
using EasyGold.Web2.Models.Comune.GEO.Entities;

namespace EasyGold.API.Services.Interfaces
{
    public interface IIndirizziService
    {
        Task<BaseListResponse<IndirizziDTO>> GetAllAsync(IndirizziListRequest filter, string language);
        Task<IndirizziDTO> GetByIdAsync(int id, string language);
        Task<IndirizziDTO> AddAsync(IndirizziDTO dto, string language);
        Task<IndirizziDTO> UpdateAsync(IndirizziDTO dto, string language);
        Task DeleteAsync(int id);
    }
}