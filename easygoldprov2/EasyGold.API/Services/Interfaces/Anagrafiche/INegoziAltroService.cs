using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.Anagrafiche
{
    public interface INegoziAltroService
    {
        Task<BaseListResponse<NegoziAltroDTO>> GetAllAsync();
        Task<NegoziAltroDTO> GetByIdAsync(int id);
        Task<NegoziAltroDTO> AddAsync(NegoziAltroDTO dto);
        Task<NegoziAltroDTO> UpdateAsync(NegoziAltroDTO dto);
        Task DeleteAsync(int id);
    }
}