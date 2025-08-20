using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_causali_lang")]
    public class DbCausaliLang
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        [Key]
        public int Cal_ISONum { get; set; }

        /// <summary>
        /// ID della causale a cui è associata la traduzione.
        /// </summary>
        public int Cal_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta della causale.
        /// </summary>
        [StringLength(100)]
        public string Cal_Descrizione { get; set; }

        [ForeignKey("Cal_IDAuto")]
        public DbCausali Causale { get; set; }
    }

}
