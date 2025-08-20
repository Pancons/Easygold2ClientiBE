// Easygold2BE/EasyGold.Web2.Models/Models/Cliente/Entities/Payment/DbCreditCardLang.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_creditCard_lang")]
    public class DbCreditCardLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int CrcId_ISONum { get; set; }

        /// <summary>
        /// ID della carta di credito principale.
        /// </summary>
        public int CrcId_ID { get; set; }

        /// <summary>
        /// Descrizione del Pagamento tradotto nella lingua specifica.
        /// </summary>
        [StringLength(100)]
        public string CrcId_Brand { get; set; }

        [ForeignKey("CrcId_ID")]
        public virtual DbCreditCard CreditCard { get; set; }
    }
}