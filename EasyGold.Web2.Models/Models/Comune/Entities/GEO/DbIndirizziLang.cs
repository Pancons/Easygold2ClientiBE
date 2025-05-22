using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    /// <summary>
    /// Entità per la tabella dbo.tbco_indirizzi_lang (traduzioni Indirizzi).
    /// </summary>
    [Table("tbco_indirizzi_lang")]
    public class DbIndirizziLang : BaseDbEntity
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
        /// Nome dell’indirizzo tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(300)]
        public string StridDescrizione { get; set; }
    }
}