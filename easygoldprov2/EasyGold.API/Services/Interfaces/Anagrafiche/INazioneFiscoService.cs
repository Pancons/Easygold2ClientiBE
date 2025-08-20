using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.Anagrafiche
{
    public interface INazioneFiscoService
    {
        Task<BaseListResponse<NazioneFiscoDTO>> GetAllAsync(NazioneFiscoListRequest request);
        Task<NazioneFiscoDTO> GetByIdAsync(int id);
        Task<NazioneFiscoDTO> AddAsync(NazioneFiscoDTO dto);
        Task<NazioneFiscoDTO> UpdateAsync(NazioneFiscoDTO dto);
        Task DeleteAsync(int id);
    }
}