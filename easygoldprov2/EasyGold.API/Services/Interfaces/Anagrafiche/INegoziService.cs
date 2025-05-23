using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.Anagrafiche
{
    public interface INegoziService
    {
        Task<BaseListResponse<NegoziDTO>> GetAllAsync();
        Task<NegoziDTO> GetByIdAsync(int id);
        Task<NegoziDTO> AddAsync(NegoziDTO dto);
        Task<NegoziDTO> UpdateAsync(NegoziDTO dto);
        Task DeleteAsync(int id);
    }
}