using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IImpFinanziarieService
    {
        Task<BaseListResponse<ImpFinanziarieDTO>> GetAllAsync(ImpFinanziarieListRequest filter, string language);
        Task<ImpFinanziarieDTO> GetByIdAsync(int id, string language);
        Task<ImpFinanziarieDTO> AddAsync(ImpFinanziarieDTO dto, string language);
        Task<ImpFinanziarieDTO> UpdateAsync(ImpFinanziarieDTO dto, string language);
        Task DeleteAsync(int id);
    }
}