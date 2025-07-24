using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyGold.Web2.Models;
using EasyGold.Web2.Models.Cliente.ACL.Filters;
using EasyGold.Web2.Models.Cliente.Entities.ACL;


namespace EasyGold.API.Services.Interfaces.ACL
{
    public interface IAutenticazioneService
    {
        /// <summary>
        /// Autentica un utente tramite username, password e subdomain, restituendo JWT e refresh token.
        /// </summary>
        /// <param name="username">Nome utente</param>
        /// <param name="password">Password</param>
        /// <param name="subdomain">Sottodominio</param>
        /// <returns>ObjectResult con dettagli token</returns>
        Task<ObjectResult> LoginAsync(string username, string password, string subdomain);

        /// <summary>
        /// Rinnova un JWT dato un token di refresh valido.
        /// </summary>
        /// <param name="refreshToken">Il token di refresh</param>
        /// <returns>ObjectResult con nuovo JWT e refresh token</returns>
        Task<ObjectResult> RefreshTokenAsync(string refreshToken);

        /// <summary>
        /// Esegue il logout revocando i token associati.
        /// </summary>
        /// <param name="userId">ID dell'utente</param>
        /// <returns>Task</returns>
        Task LogoutAsync(int userId);

        /// <summary>
        /// Cambia la password dell'utente verificando la password attuale.
        /// </summary>
        /// <param name="userId">ID dell'utente</param>
        /// <param name="oldPassword">Vecchia password</param>
        /// <param name="newPassword">Nuova password</param>
        /// <returns>True se il cambio è avvenuto con successo</returns>
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);

        
        /// <summary>
        /// Gestisce la richiesta di reset della password inviando un'email con un token di reset.
        /// </summary>
        /// <param name="email">Email dell'utente</param>
        /// <returns>ObjectResult indicante il risultato della richiesta</returns>
        Task<ObjectResult> ForgotPasswordAsync(string email);

        /// <summary>
        /// Resetta la password utilizzando un token di reset valido.
        /// </summary>
        /// <param name="token">Token di reset password</param>
        /// <param name="newPassword">Nuova password</param>
        /// <returns>ObjectResult indicante il risultato del reset</returns>
        Task<ObjectResult> ResetPasswordAsync(string token, string newPassword);

        Task<bool> SetLanguageInRefreshTokenAsync(string token, string language);

        Task<bool> SetStoreInRefreshTokenAsync(string token, int storeId);
    }
}