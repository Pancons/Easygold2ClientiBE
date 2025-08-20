using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    /// <summary>
    /// DTO per le traduzioni degli indirizzi.
    /// </summary>
    public class IndirizziLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        public int Strid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del record della tabella principale dell'indirizzo.")]
        public int Strid_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione tradotta dell'indirizzo.")]
        [StringLength(300)]
        public string Strid_Descrizione { get; set; }
    }
}