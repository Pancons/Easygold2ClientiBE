using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces
{
    public interface IUtenteNegoziService
    {
        Task<BaseListResponse<UtenteNegoziDTO>> GetAllAsync();
        Task<UtenteNegoziDTO> GetByIdAsync(int id);
        Task<UtenteNegoziDTO> AddAsync(UtenteNegoziDTO dto);
        Task<UtenteNegoziDTO> UpdateAsync(UtenteNegoziDTO dto);
        Task DeleteAsync(int id);
    }
}