using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    /// <summary>
    /// Entità per la tabella dbo.tbco_statoRegioni (Stati/Regioni).
    /// </summary>
    [Table("tbco_statoRegioni")]
    public class DbStatoRegioni : BaseDbEntity
    {
        /// <summary>
        /// È il numero ISO 3166-1 della Nazione (ntn_ISO1).
        /// </summary>
        [Required]
        public int StrIso1 { get; set; }

        /// <summary>
        /// Codice Stato/Regione (PK).
        /// </summary>
        [Key]
        public int StrIdAuto { get; set; }

        /// <summary>
        /// Stato/Nazione.
        /// </summary>
        [StringLength(200)]
        public string StrDescrizione { get; set; }

        /// <summary>
        /// Codice del Capoluogo dello Stato/Regione (nullable).
        /// </summary>
        public int? StrCodCapoluogo { get; set; }
    }
}