using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_nazioniMondo")]
    public class DbNazioniMondo : BaseDbEntity
    {
      /// <summary>
        /// Campo Numerico Intero Auto. Identificativo unico della nazione.
        /// </summary>
        [Key]
        public int Nzm_IDAuto { get; set; }

        /// <summary>
        /// Nome della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Nzm_Nazione { get; set; }

        /// <summary>
        /// Codice ISO alfanumerico di 2 lettere che identifica la nazione.
        /// </summary>
        [StringLength(2)]
        public string Nzm_ISOAlfa2 { get; set; }

        /// <summary>
        /// Codice ISO alfanumerico di 3 lettere che identifica la nazione.
        /// </summary>
        [StringLength(3)]
        public string Nzm_ISOAlfa3 { get; set; }

        /// <summary>
        /// Codice ISO numerico che identifica la nazione.
        /// </summary>
        public int Nzm_ISONum { get; set; }

        /// <summary>
        /// Prefisso telefonico della Nazione.
        /// </summary>
        [StringLength(10)]
        public string Nzm_PrefTelefonico { get; set; }

        /// <summary>
        /// Capitale legale della nazione.
        /// </summary>
        [StringLength(100)]
        public string Nzm_CapitaleIure { get; set; }

        /// <summary>
        /// Capitale di fatto della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Nzm_CapitaleFatto { get; set; }

        /// <summary>
        /// Capitale amministrativa della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Nzm_CapitaleAmm { get; set; }

        /// <summary>
        /// Capitale nella lingua locale della Nazione.
        /// </summary>
        [StringLength(200)]
        public string Nzm_CapitaleIdioma { get; set; }

        public virtual ICollection<DbNazioniMondoLang> NazioniMondoLang { get; set; } = new List<DbNazioniMondoLang>();
    }
}