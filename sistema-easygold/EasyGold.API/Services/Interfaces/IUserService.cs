using System.Threading.Tasks;
using EasyGold.API.Models.Entities;

namespace EasyGold.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<DbUtente> AuthenticateAsync(string username, string password);
        Task<bool> RegisterUserAsync(string username, string password, int tipoAbilitazione);
    }
}
