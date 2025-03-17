using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.API.Models.Clienti
{
    public class ClienteListRequest
    {
        [SwaggerSchema(Description = "Filtri per la ricerca dei clienti")]
        public ClienteFilter? Filters { get; set; }

        [SwaggerSchema(Description = "Offset per la paginazione dei risultati")]
        public int Offset { get; set; } = 0;

        [SwaggerSchema(Description = "Limite massimo di risultati da restituire")]
        public int Limit { get; set; } = 20;

        [SwaggerSchema(Description = "Opzioni di ordinamento")]
        public SortOptions? Sort { get; set; }
    }

    public class ClienteFilter
    {
        [SwaggerSchema(Description = "Ragione sociale del cliente")]
        public string DtcRagioneSociale { get; set; }

        [SwaggerSchema(Description = "Nome della gioielleria del cliente")]
        public string DtcGioielleria { get; set; }

        [SwaggerSchema(Description = "Lista di ID dei moduli")]
        public List<int> MdcIDModuli { get; set; }

        [SwaggerSchema(Description = "Indica se includere clienti non attivi")]
        public bool? NonAttivi { get; set; }

        [SwaggerSchema(Description = "Indica se includere clienti scaduti")]
        public bool? Scaduti { get; set; }
    }

    public class SortOptions
    {
        [SwaggerSchema(Description = "Campo su cui ordinare")]
        public string Field { get; set; }

        [SwaggerSchema(Description = "Ordine di ordinamento (ascendente o discendente)")]
        public string Order { get; set; } = "asc";
    }
}
