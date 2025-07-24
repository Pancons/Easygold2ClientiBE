using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL.Filters
{

    public class SessioniEasyGoldListRequest : BaseListRequest
    {  
        [SwaggerSchema(Description = "Filtri per la ricerca dei clienti")]
        public SessioniEasyGoldFiltriDTO? Filters { get; set; }
    }

    public class SessioniEasyGoldFiltriDTO
    {
        [SwaggerSchema(Description = "Identificativo opzionale dell'utente")]
        public int? IDUtente { get; set; }

    }
}
