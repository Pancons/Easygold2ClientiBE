using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_creditCard")]
    public class DbCreditCard : BaseDbEntity
    {
        /// <summary>
        /// ID auto-incrementale della carta di credito.
        /// </summary>
        [Key]
        public int Crc_IDAuto { get; set; }

        /// <summary>
        /// Descrizione del Pagamento Elettronico.
        /// </summary>
        [StringLength(100)]
        public string Crc_Card { get; set; }

        /// <summary>
        /// Commissione in percentuale della carta di pagamento.
        /// </summary>
        public decimal Crc_Fee { get; set; }

        /// <summary>
        /// Posizione nella tabella delle condizioni di pagamento.
        /// </summary>
        public int Crc_Ordinamento { get; set; }

        /// <summary>
        /// Indica se la carta è annullata.
        /// </summary>
        public bool Crc_Annulla { get; set; }

        public virtual ICollection<DbCreditCardLang> CreditCardLangs { get; set; } = new List<DbCreditCardLang>();
    }
}