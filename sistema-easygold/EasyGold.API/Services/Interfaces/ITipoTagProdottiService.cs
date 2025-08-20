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
    public interface ITipoTagProdottiService
    {
        Task<BaseListResponse<TipoTagProdottiDTO>> GetAllAsync(TipoTagProdottiListRequest filter);
        Task<TipoTagProdottiDTO> GetByIdAsync(int id);
        Task<TipoTagProdottiDTO> AddAsync(TipoTagProdottiDTO dto);
        Task<TipoTagProdottiDTO> UpdateAsync(TipoTagProdottiDTO dto);
        Task DeleteAsync(int id);
    }
}