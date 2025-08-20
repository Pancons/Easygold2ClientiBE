using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_valute_lang")]
    public class DbValuteLang
    {
        /// <summary>
        /// Codice ISO della lingua di traduzione.
        /// </summary>
        public int Valid_ISONum { get; set; }

        /// <summary>
        /// ID del record principale della valuta tradotto.
        /// </summary>
        public int Valid_ID { get; set; }

        /// <summary>
        /// Descrizione della valuta tradotta.
        /// </summary>
        [StringLength(100)]
        public string Valid_Descrizione { get; set; }

        [ForeignKey("Valid_ID")]
        public virtual DbValute Valuta { get; set; }
    }
}