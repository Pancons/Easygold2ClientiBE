using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IGruppiService
    {
        Task<BaseListResponse<GruppiDTO>> GetAllAsync(GruppiListRequest filter, string language);
        Task<GruppiDTO> GetByIdAsync(int id, string language);
        Task<GruppiDTO> AddAsync(GruppiDTO dto,  string language);
        Task<GruppiDTO> UpdateAsync(GruppiDTO dto,  string language);
        Task DeleteAsync(int id);
    }
}