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
    public interface IStatoRegioniService
    {
        Task<BaseListResponse<StatoRegioniDTO>> GetAllAsync(StatoRegioniListRequest request);
        Task<StatoRegioniDTO> GetByIdAsync(int id);
        Task<StatoRegioniDTO> AddAsync(StatoRegioniDTO dto);
        Task<StatoRegioniDTO> UpdateAsync(StatoRegioniDTO dto);
        Task DeleteAsync(int id);
    }
}