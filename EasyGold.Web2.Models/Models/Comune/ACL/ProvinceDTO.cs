using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per Provincia.
    /// </summary>
    public class ProvinceDTO
    {
        [SwaggerSchema(Description = "Numero ISO 3166-1 della Nazione (ntn_ISO1).")]
        public int StrIso1 { get; set; }

        [SwaggerSchema(Description = "Codice Provincia (PK).")]
        public int StrIdAuto { get; set; }

        [SwaggerSchema(Description = "Nome della Provincia.")]
        [StringLength(200)]
        public string StrDescrizione { get; set; }

        [SwaggerSchema(Description = "Sigla della Provincia sulla targa dell’automobile.")]
        [StringLength(20)]
        public string StrSiglaTargaAuto { get; set; }

        [SwaggerSchema(Description = "Codice dello Stato/Regione a cui appartiene la Provincia.")]
        public int StrCodStatoRegione { get; set; }
    }
}