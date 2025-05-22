using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO
{
    public class LocalitaDTO
    {
        [SwaggerSchema(Description = "È il codice della Località.")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il numero ISO 3166 1 della Nazione. È il campo ntn_ISO1 della tabella dbo.tbco_ISONazioni")]
        public int? Str_ISO1 { get; set; }

        [SwaggerSchema(Description = "È la Località.")]
        [StringLength(200)]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "È il codice dello Stato/Regione a cui appartiene la Provincia")]
        public int? Str_CodStatoRegione { get; set; }

        [SwaggerSchema(Description = "Questo campo è inserito solo se la Nazione ha le Province altrimenti sarà a NULL")]
        public int? Str_CodProvincia { get; set; }

        [SwaggerSchema(Description = "È il CAP della Località se unico per tutti gli indirizzi.")]
        [StringLength(10)]
        public string? Str_Cap { get; set; }
    }
}
