using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class SessioniEasyGoldDTO  
    {
        [SwaggerSchema(Description = "Campo numerico auto")]
        public int Sse_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il codice Cliente con cui l’Utente sta facendo il Login.")]
        public int Sse_IDCliente { get; set; }

        [SwaggerSchema(Description = "È il codice dell’Utente che ha fatto il Login.")]
        public int Sse_IDUtente { get; set; }

        [SwaggerSchema(Description = "È la Data e l’Ora della Login.")]
        public DateTime? Sse_DataLogin { get; set; }

        [SwaggerSchema(Description = "Se a True la sessione è terminata.")]
        public bool Sse_SesScaduta { get; set; }

        [SwaggerSchema(Description = "È la Data e l’Ora del Logout da Easygold.")]
        public DateTime? Sse_DataLogout { get; set; }

        [SwaggerSchema(Description = "Se a True la sessione è terminata in automatico ma non dall’Utente.")]
        public bool? Sse_sesForzata { get; set; }

        [SwaggerSchema(Description = "È la Data e l’Ora del Logout forzato.")]
        public DateTime? Sse_DataLogoutForzato { get; set; }
    }
}
