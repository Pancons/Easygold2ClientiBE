using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.API.Models.DTO.Utenti
{

    public class UtentiListRequest : BaseListRequest
    {
        [SwaggerSchema(Description = "Filtri per la ricerca dei clienti")]
        public UserFilterDTO? Filters { get; set; }
    }

    public class UserFilterDTO
    {
        [SwaggerSchema(Description = "Identificativo opzionale dell'utente")]
        public int? IDUtente { get; set; }

        [SwaggerSchema(Description = "Cognome dell'utente")]
        public string? Utw_Cognome { get; set; }

        [SwaggerSchema(Description = "Identificativo opzionale del ruolo dell'utente")]
        public int? Utw_IDRuolo { get; set; }

    }
}
