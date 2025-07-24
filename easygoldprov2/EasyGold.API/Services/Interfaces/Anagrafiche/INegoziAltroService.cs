using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.Anagrafiche
{
    public interface INegoziAltroService
    {
        Task<BaseListResponse<NegozioAltroDTO>> GetAllAsync(NegozioAltroListRequest filter);
        Task<NegozioAltroDTO> GetByIdAsync(int id);
        Task<NegozioAltroDTO> AddAsync(NegozioAltroDTO dto);
        Task<NegozioAltroDTO> UpdateAsync(NegozioAltroDTO dto);
        Task DeleteAsync(int id);
    }
}