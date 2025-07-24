using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IUtenteService
    {
        Task<BaseListResponse<UtenteDTO>> GetAllAsync(BaseListRequest request);
        Task<UtenteDTO> GetByIdAsync(int id);
        Task<UtenteDTO> AddAsync(UtenteDTO dto);
        Task<UtenteDTO> UpdateAsync(UtenteDTO dto);
        Task DeleteAsync(int id);
    }
}