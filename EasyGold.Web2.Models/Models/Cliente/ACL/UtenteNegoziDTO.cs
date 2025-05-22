using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per UtenteNegozi.
    /// </summary>
    public class UtenteNegoziDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale utente negozio.")]
        public int Utn_ID { get; set; }

        [SwaggerSchema(Description = "ID negozio.")]
        public int Utn_IDNegozio { get; set; }

        [SwaggerSchema(Description = "Se true, utente non ha più accesso al negozio.")]
        public bool Utn_Annullato { get; set; }
    }
}