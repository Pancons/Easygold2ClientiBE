using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    /// <summary>
    /// Entità per la tabella dbo.tbco_province_lang (traduzioni Province).
    /// </summary>
    [Table("tbco_province_lang")]
    public class DbProvinceLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        [Required]
        public int StridISONum { get; set; }

        /// <summary>
        /// Numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        [Required]
        public int StridID { get; set; }

        /// <summary>
        /// Nome della Provincia tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(200)]
        public string StridDescrizione { get; set; }
    }
}