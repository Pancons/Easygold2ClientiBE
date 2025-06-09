using System.Threading.Tasks;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IAutenticazioneService
    {
        Task<DbUtente> AuthenticateAsync(string username, string password);
        Task<bool> RegisterUserAsync(string username, string password, int tipoAbilitazione);
        Task<int> GetTokenExpiryMinutesAsync();
        bool IsRequestFromEasygoldFrontend(HttpRequest request);

    }
}
