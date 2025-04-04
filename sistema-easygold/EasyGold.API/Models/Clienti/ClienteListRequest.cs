using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.API.Models.Clienti
{
    public class ClienteListRequest : BaseListRequest
    {
        [SwaggerSchema(Description = "Filtri per la ricerca dei clienti")]
        public ClienteFilter? Filters { get; set; }
    }

    public class ClienteFilter
    {
        [SwaggerSchema(Description = "Ragione sociale del cliente")]
        public string? DtcRagioneSociale { get; set; }

        [SwaggerSchema(Description = "Nome della gioielleria del cliente")]
        public string? DtcGioielleria { get; set; }

        [SwaggerSchema(Description = "Lista di ID dei moduli")]
        public List<int>? MdcIDModuli { get; set; }

        [SwaggerSchema(Description = "Indica se includere clienti non attivi")]
        public bool? NonAttivi { get; set; }

        [SwaggerSchema(Description = "Indica se includere clienti scaduti")]
        public bool? Scaduti { get; set; }
    }
}
