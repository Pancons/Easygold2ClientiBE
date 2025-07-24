using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IFunzioniService
    {
        Task<BaseListResponse<FunzioniDTO>> GetAllAsync(FunzioniListRequest filter, string language);
        Task<FunzioniDTO> GetByIdAsync(int id, string language);
        Task<FunzioniDTO> AddAsync(FunzioniDTO dto, string language);
        Task<FunzioniDTO> UpdateAsync(FunzioniDTO dto, string language);
        Task DeleteAsync(int id);
    }
}