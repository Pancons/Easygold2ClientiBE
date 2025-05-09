using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class PwUtentiDTO
    {
        [SwaggerSchema(Description = "Campo numero intero auto.")]
        public int Utp_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il campo ute_IDAuto della tabella dbo.tbcl_utenti.")]
        public int Utp_IDUtente { get; set; }

        [SwaggerSchema(Description = "È il campo tpp_IDAuto della tabella dbo.tbco_tipoPw.")]
        public int Utp_TipoPw { get; set; }

        [SwaggerSchema(Description = "è La password dell'utente")]
        [StringLength(100)]
        public string Utp_PwUtente { get; set; }
    }
}
