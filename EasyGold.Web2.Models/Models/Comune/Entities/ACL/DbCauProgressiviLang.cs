using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_cauProgressivi_lang")]
    public class DbCauProgressiviLang
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        [Key]
        public int Prcid_ISONum { get; set; }

        /// <summary>
        /// ID del progressivo a cui è associata la traduzione.
        /// </summary>
        public int Prcid_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta del progressivo.
        /// </summary>
        [StringLength(50)]
        public string Prcid_Descrizione { get; set; }

        [ForeignKey("Prcid_ID")]
        public virtual DbCauProgressivi CauProgressivo { get; set; }
    }
}