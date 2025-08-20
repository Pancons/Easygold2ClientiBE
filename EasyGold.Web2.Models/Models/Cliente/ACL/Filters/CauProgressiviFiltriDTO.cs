using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL.Filters
{

    public class CauProgressiviListRequest : BaseListRequest
    {
        [SwaggerSchema(Description = "Filtri per la ricerca dei clienti")]
        public CauProgressiviFiltriDTO? Filters { get; set; }
    }

    public class CauProgressiviFiltriDTO
    {
        [SwaggerSchema(Description = "Identificativo opzionale dell'utente")]
        public int? IDUtente { get; set; }

        [SwaggerSchema(Description = "Cognome dell'utente")]
        public string? Utw_Cognome { get; set; }

    }
}