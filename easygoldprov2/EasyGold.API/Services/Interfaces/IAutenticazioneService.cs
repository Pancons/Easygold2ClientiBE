using System.Threading.Tasks;
using EasyGold.API.Models.Entities.Utenti;

namespace EasyGold.API.Services.Interfaces
{
    public interface IAutenticazioneService
    {
        Task<DbUtente> AuthenticateAsync(string username, string password);
        Task<bool> RegisterUserAsync(string username, string password, int tipoAbilitazione);
        Task<int> GetTokenExpiryMinutesAsync();
       bool IsRequestFromEasygoldFrontend(HttpRequest request);
       
    }
}
