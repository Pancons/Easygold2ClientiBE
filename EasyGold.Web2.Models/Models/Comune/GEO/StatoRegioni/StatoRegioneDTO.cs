using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.StatoRegioni
{
    public class StatoRegioneDTO
    {
        [SwaggerSchema(Description = "È il codice dello Stato/Regione")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il numero ISO 3166 1 della Nazione")]
        public int? Str_ISO1 { get; set; }
        
        [StringLength(200)]
        [SwaggerSchema(Description = "È lo Stato/Nazione")]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "È il codice del Capoluogo dello Stato/Regione")]
        public int? Str_CodCapoluogo { get; set; }
    }
}
