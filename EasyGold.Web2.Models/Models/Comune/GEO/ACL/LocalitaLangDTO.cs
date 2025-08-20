using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    /// <summary>
    /// DTO per le traduzioni delle Località.
    /// </summary>
    public class LocalitaLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        [Required]
        public int Strid_ISONum { get; set; }

        [SwaggerSchema(Description = "Numero del record della tabella principale della Località.")]
        [Required]
        public int Strid_ID { get; set; }

        [SwaggerSchema(Description = "Nome tradotto della Località.")]
        [StringLength(200)]
        [Required]
        public string Strid_Descrizione { get; set; }
    }
}