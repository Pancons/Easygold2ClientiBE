using System.Collections.Generic;
using System.Threading.Tasks;
using EasyGold.API.Models.Utenti;

namespace EasyGold.API.Services.Interfaces
{
    public interface IUtenteService
    {
        /*
        Task<IEnumerable<UtenteDTO>> GetAllAsync();
        Task<UtenteDettaglioDTO> GetByIdAsync(int id);
        Task AddAsync(UtenteDettaglioDTO utenteDettaglioDto);
        Task UpdateAsync(UtenteDettaglioDTO utenteDettaglioDto);
        Task DeleteAsync(int id);
        */
        Task<(IEnumerable<UtenteDTO> Users, int Total)> GetUsersListAsync(UserFilterDTO filter);
        Task AddAsync(UtenteDTO utenteDettaglioDto);
        Task UpdateAsync(UtenteDTO utenteDettaglioDto);

        Task<UtenteDTO> GetUserByIdAsync(int id);
    }
}
