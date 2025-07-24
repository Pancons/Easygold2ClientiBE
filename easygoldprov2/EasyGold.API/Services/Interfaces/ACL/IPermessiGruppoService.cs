using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IPermessiGruppoService
    {
        Task<BaseListResponse<PermessiGruppoDTO>> GetAllAsync(PermessiGruppoListRequest filter);
        Task<PermessiGruppoDTO> GetByIdAsync(int id);
        Task<PermessiGruppoDTO> AddAsync(PermessiGruppoDTO dto);
        Task<PermessiGruppoDTO> UpdateAsync(PermessiGruppoDTO dto);
        Task DeleteAsync(int id);
    }
}