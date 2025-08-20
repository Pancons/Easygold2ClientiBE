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
    public interface ICausaliComuneService
    {
        Task<BaseListResponse<CausaliComuneDTO>> GetAllAsync(CausaliComuneListRequest filter, string language);
        Task<CausaliComuneDTO> GetByIdAsync(int id, string language);
        Task<CausaliComuneDTO> AddAsync(CausaliComuneDTO dto, string language);
        Task<CausaliComuneDTO> UpdateAsync(CausaliComuneDTO dto, string language);
        Task DeleteAsync(int id);
    }
}