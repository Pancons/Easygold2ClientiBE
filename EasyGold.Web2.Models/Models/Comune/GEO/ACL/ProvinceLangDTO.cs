using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    /// <summary>
    /// DTO per la traduzione delle Province.
    /// </summary>
    public class ProvinceLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        [Required]
        public int Strid_ISONum { get; set; }

        [SwaggerSchema(Description = "Numero del record della tabella principale della Provincia.")]
        [Required]
        public int Strid_ID { get; set; }

        [SwaggerSchema(Description = "Nome tradotto della Provincia.")]
        [StringLength(200)]
        public string Strid_Descrizione { get; set; }
    }
}