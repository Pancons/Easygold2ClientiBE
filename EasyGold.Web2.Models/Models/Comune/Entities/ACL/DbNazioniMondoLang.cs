using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_nazioniMondo_lang")]
    public class DbNazioniMondoLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua in cui sono stati tradotti i testi.
        /// </summary>
        public int Nzmid_ISONum { get; set; }

        /// <summary>
        /// Identificativo del record della tabella principale a cui fa riferimento.
        /// </summary>
        public int Nzmid_ID { get; set; }

        /// <summary>
        /// Nome tradotto della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Nzmid_Nazione { get; set; }

        /// <summary>
        /// Capitale legale della nazione tradotta nella lingua selezionata.
        /// </summary>
        [StringLength(100)]
        public string Nzmid_CapitaleIure { get; set; }

        /// <summary>
        /// Capitale di fatto della nazione tradotta nella lingua selezionata.
        /// </summary>
        [StringLength(100)]
        public string Nzmid_CapitaleFatto { get; set; }

        /// <summary>
        /// Capitale amministrativa della nazione tradotta nella lingua selezionata.
        /// </summary>
        [StringLength(100)]
        public string Nzmid_CapitaleAmm { get; set; }

        [ForeignKey("Nzmid_ID")]
        public virtual DbNazioniMondo NazioneMondo { get; set; }
    }
}