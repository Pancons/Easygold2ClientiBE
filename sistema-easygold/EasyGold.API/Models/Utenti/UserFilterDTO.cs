using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.API.Models.Utenti
{

    public class UtentiListRequest
    {
        [SwaggerSchema(Description = "Filtri per la ricerca dei clienti")]
        public UserFilterDTO? Filters { get; set; }

        [SwaggerSchema(Description = "Offset per la paginazione dei risultati")]
        public int Offset { get; set; } = 0;

        [SwaggerSchema(Description = "Limite massimo di risultati da restituire")]
        public int Limit { get; set; } = 20;

        [SwaggerSchema(Description = "Opzioni di ordinamento")]
        public List<SortDTO>? Sort { get; set; }
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

    public class SortDTO
    {
        [SwaggerSchema(Description = "Campo su cui ordinare")]
        public string Field { get; set; }

        [SwaggerSchema(Description = "Ordine di ordinamento (ascendente o discendente)")]
        public string Order { get; set; }
    }
}
