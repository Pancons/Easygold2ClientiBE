using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    /// <summary>
    /// DTO per Località.
    /// </summary>
    public class LocalitaDTO
    {
        [SwaggerSchema(Description = "Numero ISO 3166 1 della Nazione.")]
        public int Str_ISO1 { get; set; }

        [SwaggerSchema(Description = "Codice della Località.")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "Nome della Località.")]
        [StringLength(200)]
        [Required]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "Codice dello Stato/Regione a cui appartiene la Località.")]
        public int Str_CodStatoRegione { get; set; }

        [SwaggerSchema(Description = "Codice della Provincia a cui appartiene la Località.")]
        public int? Str_CodProvincia { get; set; }

        [SwaggerSchema(Description = "CAP della Località.")]
        [StringLength(10)]
        public string Str_CAP { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni per la località.")]
        public List<LocalitaLangDTO> Traduzioni { get; set; } = new List<LocalitaLangDTO>();
    }
}