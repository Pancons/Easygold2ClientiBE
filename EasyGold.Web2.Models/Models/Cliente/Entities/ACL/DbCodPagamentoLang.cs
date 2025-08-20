using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_codPagamento_lang")]
    public class DbCodPagamentoLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int CpaId_ISONum { get; set; }

        /// <summary>
        /// ID della condizione di pagamento principale.
        /// </summary>
        public int CpaId_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta nella lingua specifica.
        /// </summary>
        [StringLength(100)]
        public string CpaId_Descrizione { get; set; }

        [ForeignKey("CpaId_ID")]
        public virtual DbCodPagamento CodPagamento { get; set; }
    }
}