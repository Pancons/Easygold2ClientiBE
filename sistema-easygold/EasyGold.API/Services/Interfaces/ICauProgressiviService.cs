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
    public interface ICauProgressiviService
    {
        Task<BaseListResponse<CauProgressiviDTO>> GetAllAsync(CauProgressiviListRequest filter, string language);
        Task<CauProgressiviDTO> GetByIdAsync(int id, string language);
        Task<CauProgressiviDTO> AddAsync(CauProgressiviDTO dto, string language);
        Task<CauProgressiviDTO> UpdateAsync(CauProgressiviDTO dto, string language);
        Task DeleteAsync(int id);
    }
}