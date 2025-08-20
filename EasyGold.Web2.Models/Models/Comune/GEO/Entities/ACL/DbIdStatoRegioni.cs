using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_id_statoRegioni")]
    public class DbIdStatoRegioni
    {
        /// <summary>
        /// Codice ISO della lingua di traduzione.
        /// </summary>
        public int Strid_ISONum { get; set; }

        /// <summary>
        /// ID del record principale dello Stato/Regione tradotto.
        /// </summary>
        public int Strid_ID { get; set; }

        /// <summary>
        /// Nome tradotto dello Stato/Nazione.
        /// </summary>
        [StringLength(200)]
        public string Strid_Descrizione { get; set; }

        [ForeignKey("Strid_ID")]
        public virtual DbStatoRegioni StatoRegione { get; set; }
    }
}