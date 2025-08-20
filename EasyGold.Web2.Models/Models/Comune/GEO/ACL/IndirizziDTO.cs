using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    /// <summary>
    /// DTO per gli indirizzi.
    /// </summary>
    public class IndirizziDTO
    {
        [SwaggerSchema(Description = "Numero ISO 3166 1 della Nazione.")]
        public int Str_ISO1 { get; set; }

        [SwaggerSchema(Description = "Codice della Località.")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "Indirizzo della Città.")]
        [StringLength(300)]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "Codice della Località.")]
        public int Str_CodLocalita { get; set; }

        [SwaggerSchema(Description = "CAP dell'indirizzo.")]
        [StringLength(10)]
        public string Str_CAP { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni per l'indirizzo.")]
        public List<IndirizziLangDTO> Traduzioni { get; set; } = new List<IndirizziLangDTO>();
    }
}