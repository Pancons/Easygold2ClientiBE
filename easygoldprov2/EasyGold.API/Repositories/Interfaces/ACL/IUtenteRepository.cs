using EasyGold.API.Models.DTO.Utenti;
using EasyGold.API.Models.Entities.Utenti;
namespace EasyGold.API.Repositories.Interfaces.ACL
{
    public interface IUtenteRepository
    {

        /*
        Task<IEnumerable<DbUtente>> GetAllAsync();
        Task<DbUtente> GetByIdAsync(int id);
      
        Task DeleteAsync(int id);
        */
        Task<(IEnumerable<DbUtente> Users, int Total)> GetUsersListAsync(UtentiListRequest filter);
        Task<DbUtente> GetUserByIdAsync(int id);

        Task AddAsync(DbUtente utente);
        Task UpdateAsync(DbUtente utente);

        Task DeleteAsync(int id);
    }
}
