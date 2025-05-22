using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per Indirizzo.
    /// </summary>
    public class IndirizziDTO
    {
        [SwaggerSchema(Description = "Numero ISO 3166-1 della Nazione (ntn_ISO1).")]
        public int StrIso1 { get; set; }

        [SwaggerSchema(Description = "Codice Indirizzo (PK).")]
        public int StrIdAuto { get; set; }

        [SwaggerSchema(Description = "Indirizzo della Città.")]
        [StringLength(300)]
        public string StrDescrizione { get; set; }

        [SwaggerSchema(Description = "Codice della Località a cui appartiene l’indirizzo.")]
        public int StrCodLocalita { get; set; }

        [SwaggerSchema(Description = "CAP dell’indirizzo (max 10 caratteri).")]
        [StringLength(10)]
        public string StrCAP { get; set; }
    }
}