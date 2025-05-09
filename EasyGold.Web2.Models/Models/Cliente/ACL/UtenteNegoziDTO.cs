using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class UtentiNegoziDTO
    {
        [SwaggerSchema(Description = "È il campo ute_IDAuto della tabella dbo.tbcl_utenti")]
        public int Utn_ID { get; set; }

        [SwaggerSchema(Description = "È il campo neg_IDAuto della tabella dbo.tbcl_negozi.")]
        public int Utn_IDNegozio { get; set; }

        [SwaggerSchema(Description = " Se a True l’Utente NON ha più accesso al Negozio.")]
        public bool? Utn_Annullato { get; set; }
    }
}
