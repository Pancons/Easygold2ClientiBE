using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_causali_lang")]
    public class DbCausaliComuneLang
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        [Key]
        public int Cac_ISONum { get; set; }

        /// <summary>
        /// ID della causale a cui è associata la traduzione.
        /// </summary>
        public int Cac_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta della causale.
        /// </summary>
        [StringLength(100)]
        public string Cac_Descrizione { get; set; }

        [ForeignKey("Cac_IDAuto")]
        public DbCausaliComune CausaliComune { get; set; }
    }

}
