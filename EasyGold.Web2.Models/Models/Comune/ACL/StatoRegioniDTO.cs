using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per Stato/Regione.
    /// </summary>
    public class StatoRegioniDTO
    {
        [SwaggerSchema(Description = "È il numero ISO 3166-1 della Nazione (ntn_ISO1).")]
        public int StrIso1 { get; set; }

        [SwaggerSchema(Description = "Codice Stato/Regione (PK).")]
        public int StrIdAuto { get; set; }

        [SwaggerSchema(Description = "Stato/Nazione.")]
        [StringLength(200)]
        public string StrDescrizione { get; set; }

        [SwaggerSchema(Description = "Codice del Capoluogo dello Stato/Regione (nullable).")]
        public int? StrCodCapoluogo { get; set; }
    }
}