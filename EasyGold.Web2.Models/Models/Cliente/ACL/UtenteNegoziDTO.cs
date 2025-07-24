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
        /*[SwaggerSchema(Description = "ID auto-incrementale utente negozio.")]
        public int Utn_ID { get; set; }*/

        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Utn_IDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il campo ute_IDAuto della tabella dbo.tbcl_utenti.")]
        public int Utn_IDUtente { get; set; }
        
        [SwaggerSchema(Description = "ID negozio.")]
        public int Utn_IDNegozio { get; set; }

        [SwaggerSchema(Description = "Campo Bit. Nel caso di inserimento di più postazioni per lo stesso Utente/Negozio una postazione deve avere questo campo a True. Può esserci un’unica postazione Utente/Negozio che ha questo campo a True. Se si seleziona un’altra postazione Utente/Negozio questo campo dovrò essere messo a False in automatico.")]
        public bool Utn_Default { get; set; }

        [SwaggerSchema(Description = "Se true, utente non ha più accesso al negozio.")]
        public bool Utn_Annullato { get; set; }
    }
}