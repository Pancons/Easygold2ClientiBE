using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities
{
    /// <summary>
    /// Entità per la tabella dbo.tbco_indirizzi (Indirizzi).
    /// </summary>
    [Table("tbco_indirizzi")]
    public class DbIndirizzi : BaseDbEntity
    {
        /// <summary>
        /// Numero ISO 3166-1 della Nazione (ntn_ISO1).
        /// </summary>
        [Required]
        public int StrIso1 { get; set; }

        /// <summary>
        /// Codice Indirizzo (PK).
        /// </summary>
        [Key]
        public int StrIdAuto { get; set; }

        /// <summary>
        /// Indirizzo della Città.
        /// </summary>
        [StringLength(300)]
        public string StrDescrizione { get; set; }

        /// <summary>
        /// Codice della Località a cui appartiene l’indirizzo.
        /// </summary>
        public int StrCodLocalita { get; set; }

        /// <summary>
        /// CAP dell’indirizzo (max 10 caratteri).
        /// </summary>
        [StringLength(10)]
        public string StrCAP { get; set; }
    }
}