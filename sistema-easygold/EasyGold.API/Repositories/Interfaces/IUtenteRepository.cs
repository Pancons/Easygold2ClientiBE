
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Users;
namespace EasyGold.API.Repositories.Interfaces
{
    public interface IUtenteRepository
    {

        /*
        Task<IEnumerable<DbUtente>> GetAllAsync();
        Task<DbUtente> GetByIdAsync(int id);
      
        Task DeleteAsync(int id);
        */ 
        Task<(IEnumerable<UtenteDTO> Users, int Total)> GetUsersListAsync(UserFilterDTO filter);
        Task<UtenteDTO> GetUserByIdAsync(int id);

        Task AddAsync(DbUtente utente);
        Task UpdateAsync(DbUtente utente);
    }
}
