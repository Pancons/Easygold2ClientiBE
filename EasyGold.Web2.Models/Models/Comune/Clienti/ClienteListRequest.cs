using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Comune.Clienti
{
    public class ClienteListRequest : BaseListRequest
    {
        [SwaggerSchema(Description = "Filtri per la ricerca dei clienti")]
        public ClienteFilter? Filters { get; set; }
    }

    public class ClienteFilter
    {
        [SwaggerSchema(Description = "Ragione sociale del cliente")]
        public string? Dtc_RagioneSociale { get; set; }

        [SwaggerSchema(Description = "Nome della gioielleria del cliente")]
        public string? Dtc_Gioielleria { get; set; }

        [SwaggerSchema(Description = "Lista di ID dei moduli")]
        public List<int>? Mdc_IDModulo { get; set; }

        [SwaggerSchema(Description = "Indica se includere moduli non attivi")]
        public bool? NonAttivi { get; set; }

        [SwaggerSchema(Description = "Indica se includere moduli scaduti")]
        public bool? Scaduti { get; set; }
    }
}
