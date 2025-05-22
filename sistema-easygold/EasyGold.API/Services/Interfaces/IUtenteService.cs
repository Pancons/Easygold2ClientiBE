using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models;
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Utenti;

namespace EasyGold.API.Services.Interfaces
{
    public interface IUtenteService
    {
        Task<BaseListResponse<UtenteDTO>> GetUsersListAsync(UtentiListRequest filter);
        Task<UtenteDTO> GetUserByIdAsync(int id);
        Task<bool> UsernameExist(string username);
        Task<UtenteDTO> AddAsync(UtenteDTO utenteDettaglioDto);
        Task<UtenteDTO> UpdateAsync(UtenteDTO utenteDettaglioDto);
        Task DeleteAsync(int id);
        Task<bool> ChangePassword(PasswordDTO passwordDto);
        Task<UtenteDTO> AuthenticateAsync(string username, string password);
        Task<string> CreateToken(UtenteDTO user, string secretKey, string languageId = "IT");
        Task<string> CreateToken(string username, string userRole, string secretKey, string languageId = "IT");
    }
}
