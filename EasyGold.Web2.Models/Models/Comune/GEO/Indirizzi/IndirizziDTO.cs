using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.Indirizzi
{
    public class IndirizziDTO
    {
        [SwaggerSchema(Description = "È il codice della Località.")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il numero ISO 3166 1 della Nazione. È il campo ntn_ISO1 della tabella dbo.tbco_ISONazioni")]
        public int? Str_ISO1 { get; set; }

        [SwaggerSchema(Description = "È l'indirizzo della città.")]
        [StringLength(300)]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "È il codice della località a cui appartiene l'indirizzo")]
        public int? Str_CodLocalita { get; set; }

        [SwaggerSchema(Description = "È il CAP dell’indirizzo se diverso da quello della Località.")]
        [StringLength(10)]
        public string? Str_Cap { get; set; }
    }
}
