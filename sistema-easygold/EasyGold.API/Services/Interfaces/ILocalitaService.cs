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
    public interface ILocalitaService
    {
        Task<BaseListResponse<LocalitaDTO>> GetAllAsync(LocalitaListRequest filter, string language);
        Task<LocalitaDTO> GetByIdAsync(int id, string language);
        Task<LocalitaDTO> AddAsync(LocalitaDTO dto, string language);
        Task<LocalitaDTO> UpdateAsync(LocalitaDTO dto, string language);
        Task DeleteAsync(int id);
    }
}