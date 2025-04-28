
using EasyGold.API.Models.Entities;
using EasyGold.API.Models.Utenti;
namespace EasyGold.API.Repositories.Interfaces
{
    public interface IUtenteRepository
    {
        Task<(IEnumerable<DbUtente> Users, int Total)> GetUsersListAsync(UtentiListRequest filter);
        Task<DbUtente> GetUserByIdAsync(int id);
        Task<DbUtente> GetUserByUsernameAsync(string username);
        Task<bool> UsernameExist(string username);
        Task AddAsync(DbUtente utente);
        Task UpdateAsync(DbUtente utente);
        Task DeleteAsync(int id);
    }
}
