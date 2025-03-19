using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Utenti;

namespace EasyGold.API.Services.Interfaces
{
    public interface IUtenteService
    {
       Task<(IEnumerable<UtenteDTO> Users, int Total)> GetUsersListAsync(UserFilterDTO filter);
        Task<UtenteDTO> GetUserByIdAsync(int id);
        Task<UtenteDTO> AddAsync(UtenteDTO utenteDettaglioDto);
        Task<UtenteDTO> UpdateAsync(UtenteDTO utenteDettaglioDto);
    }
}
