using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_aliquoteIVA_lang")]
    public class DbAliQuoteIVALang
    {
        /// <summary>
        /// Codice ISO della lingua di traduzione.
        /// </summary>
        public int Ivaid_ISONum { get; set; }

        /// <summary>
        /// ID del record principale dell’aliquota IVA tradotto.
        /// </summary>
        public int Ivaid_ID { get; set; }

        /// <summary>
        /// Descrizione dell’aliquota IVA tradotta.
        /// </summary>
        [StringLength(100)]
        public string Ivaid_Descrizione { get; set; }

        [ForeignKey("Ivaid_ID")]
        public virtual DbAliQuoteIVA AliQuoteIVA { get; set; }
    }
}