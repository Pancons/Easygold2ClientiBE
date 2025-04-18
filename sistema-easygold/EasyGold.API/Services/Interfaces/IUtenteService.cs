using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.Utenti;

namespace EasyGold.API.Services.Interfaces
{
    public interface IUtenteService
    {
        Task<BaseListResponse<UtenteDTO>> GetUsersListAsync(UtentiListRequest filter);
        Task<UtenteDTO> GetUserByIdAsync(int id);
        Task<bool> UsernameExist(UtenteDTO utenteDettaglioDto);
        Task<UtenteDTO> AddAsync(UtenteDTO utenteDettaglioDto);
        Task<UtenteDTO> UpdateAsync(UtenteDTO utenteDettaglioDto);
        Task DeleteAsync(int id);
    }
}
