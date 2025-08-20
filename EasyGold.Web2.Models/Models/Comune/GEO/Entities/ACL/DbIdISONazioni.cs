using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_id_ISONazioni")]
    public class DbIdISONazioni
    {
        /// <summary>
        /// Codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int Ntnid_ISONum { get; set; }

        /// <summary>
        /// Numero ID del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int Ntnid_ID { get; set; }

        /// <summary>
        /// Nome tradotto della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Ntnid_Nazione { get; set; }

        /// <summary>
        /// Capitale De Iure tradotta.
        /// </summary>
        [StringLength(100)]
        public string Ntnid_Capitale { get; set; }

        /// <summary>
        /// Capitale De Facto tradotta.
        /// </summary>
        [StringLength(100)]
        public string Ntn_CapitaleDeFacto { get; set; }

        /// <summary>
        /// Capitale Amministrativa tradotta.
        /// </summary>
        [StringLength(100)]
        public string Ntn_CapitaleAmm { get; set; }

        [ForeignKey("Ntnid_ID")]
        public virtual DbISONazioni ISONazione { get; set; }
    }
}