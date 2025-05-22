using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Password Utenti.
    /// </summary>
    public class PwUtentiDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale password.")]
        public int Utp_IDAuto { get; set; }

        [SwaggerSchema(Description = "ID utente.")]
        public int Utp_IDUtente { get; set; }

        [SwaggerSchema(Description = "Tipo password.")]
        public int Utp_TipoPw { get; set; }

        [SwaggerSchema(Description = "Password utente (criptata).")]
        [StringLength(100)]
        public string Utp_PwUtente { get; set; }
    }
}