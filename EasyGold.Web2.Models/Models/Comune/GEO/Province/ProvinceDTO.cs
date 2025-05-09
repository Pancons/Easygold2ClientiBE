using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.Province
{
    public class ProvinceDTO
    {
        [SwaggerSchema(Description = "È il codice dello Stato/Regione")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il numero ISO 3166 1 della Nazione. È il campo ntn_ISO1 della tabella dbo.tbco_ISONazioni")]
        public int? Str_ISO1 { get; set; }

        [SwaggerSchema(Description = "È la provincia")]
        [StringLength(200)]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "È la sigla della Provincia sulla targa dell’automobile")]
        [StringLength(20)]
        public string? Str_SiglaTargaAuto { get; set; }

        [SwaggerSchema(Description = "È il codice dello Stato/Regione a cui appartiene la Provincia")]
        public int? Str_CodStatoRegione { get; set; }

    }
}
