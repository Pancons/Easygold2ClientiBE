using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Metalli
{
    public class MetalliDTO
    {
        [SwaggerSchema("Campo Numerico Intero Auto.")]
        public int met_IDAuto { get; set; }

        [SwaggerSchema("Campo Testo fino a 100 caratteri che descrive il metallo.")]
        [StringLength(100)]
        public string met_descrizione { get; set; }

        [SwaggerSchema("Campo bit che indica se il metallo ha la necessità di quotazioni.")]
        public bool met_quotazione { get; set; }

        [SwaggerSchema("Campo bit che indica se il metallo ha necessità di descrizioni dettagliate specifiche.")]
        public bool met_tipiMetallo { get; set; }

        [SwaggerSchema("Campo bit che indica se il metallo è stato annullato.")]
        public bool met_annullato { get; set; }

        [SwaggerSchema(Description = "Quotazioni del metallo.")]
        public List<QuotazioneMetalliDTO> Quotazioni { get; set; } = new List<QuotazioneMetalliDTO>();

        [SwaggerSchema(Description = "Tipi del metallo.")]
        public List<TipiMetalloDTO> Tipi { get; set; } = new List<TipiMetalloDTO>();

        [SwaggerSchema(Description = "Traduzioni disponibili per il metallo.")]
        public List<MetalliLangDTO> Traduzioni { get; set; } = new List<MetalliLangDTO>();
    }
}