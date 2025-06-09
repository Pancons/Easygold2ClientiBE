using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IUtenteService
    {
        Task<BaseListResponse<UtenteDTO>> GetUsersListAsync(UtentiListRequest filter);
        Task<UtenteDTO> GetUserByIdAsync(int id);
        Task<UtenteDTO> AddAsync(UtenteDTO utenteDettaglioDto);
        Task<UtenteDTO> UpdateAsync(UtenteDTO utenteDettaglioDto);
        Task DeleteAsync(int id);
    }
}
