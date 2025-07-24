using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.Anagrafiche;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.Anagrafiche
{
    public interface INegoziService
    {
        Task<BaseListResponse<NegozioDTO>> GetAllAsync(NegozioListRequest filter);
        Task<NegozioDTO> GetByIdAsync(int id);
        Task<NegozioDTO> AddAsync(NegozioDTO dto);
        Task<NegozioDTO> UpdateAsync(NegozioDTO dto);
        Task DeleteAsync(int id);
    }
}