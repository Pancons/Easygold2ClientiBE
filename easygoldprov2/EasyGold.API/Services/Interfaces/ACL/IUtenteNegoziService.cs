using System.Threading.Tasks;
using System.Collections.Generic;
using EasyGold.Web2.Models.Cliente.ACL;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IUtenteNegoziService
    {
        Task<BaseListResponse<UtenteNegoziDTO>> GetAllAsync(UtenteNegoziListRequest request);
        Task<UtenteNegoziDTO> GetByIdAsync(int id);
        Task<UtenteNegoziDTO> AddAsync(UtenteNegoziDTO dto);
        Task<UtenteNegoziDTO> UpdateAsync(UtenteNegoziDTO dto);
        Task DeleteAsync(int id);
    }
}