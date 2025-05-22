using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    /// <summary>
    /// Entità per la tabella dbo.tbco_localita (Località).
    /// </summary>
    [Table("tbco_localita")]
    public class DbLocalita : BaseDbEntity
    {
        /// <summary>
        /// Numero ISO 3166-1 della Nazione (ntn_ISO1).
        /// </summary>
        [Required]
        public int StrIso1 { get; set; }

        /// <summary>
        /// Codice Località (PK).
        /// </summary>
        [Key]
        public int StrIdAuto { get; set; }

        /// <summary>
        /// Nome della Località.
        /// </summary>
        [StringLength(200)]
        public string StrDescrizione { get; set; }

        /// <summary>
        /// Codice dello Stato/Regione a cui appartiene la Località.
        /// </summary>
        public int StrCodStatoRegione { get; set; }

        /// <summary>
        /// Codice della Provincia a cui appartiene la Località (nullable).
        /// </summary>
        public int? StrCodProvincia { get; set; }

        /// <summary>
        /// CAP della Località (max 10 caratteri).
        /// </summary>
        [StringLength(10)]
        public string StrCAP { get; set; }
    }
}