using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per Località.
    /// </summary>
    public class LocalitaDTO
    {
        [SwaggerSchema(Description = "Numero ISO 3166-1 della Nazione (ntn_ISO1).")]
        public int StrIso1 { get; set; }

        [SwaggerSchema(Description = "Codice Località (PK).")]
        public int StrIdAuto { get; set; }

        [SwaggerSchema(Description = "Nome della Località.")]
        [StringLength(200)]
        public string StrDescrizione { get; set; }

        [SwaggerSchema(Description = "Codice dello Stato/Regione a cui appartiene la Località.")]
        public int StrCodStatoRegione { get; set; }

        [SwaggerSchema(Description = "Codice della Provincia a cui appartiene la Località (nullable).")]
        public int? StrCodProvincia { get; set; }

        [SwaggerSchema(Description = "CAP della Località (max 10 caratteri).")]
        [StringLength(10)]
        public string StrCAP { get; set; }
    }
}