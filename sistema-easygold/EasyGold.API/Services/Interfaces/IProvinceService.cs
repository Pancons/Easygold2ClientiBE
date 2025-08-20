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
    public interface IProvinceService
    {
        Task<BaseListResponse<ProvinceDTO>> GetAllAsync(ProvinceListRequest filter, string language);
        Task<ProvinceDTO> GetByIdAsync(int id, string language);
        Task<ProvinceDTO> AddAsync(ProvinceDTO dto, string language);
        Task<ProvinceDTO> UpdateAsync(ProvinceDTO dto, string language);
        Task DeleteAsync(int id);
    }
}