using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_tipoPagamento_lang")]
    public class DbTipoPagamentoLang
    {
        /// <summary>
        /// Codice ISO della lingua per la traduzione.
        /// </summary>
        [Key, Column(Order = 0)]
        public int Tpgid_ISONum { get; set; }

        /// <summary>
        /// ID del tipo di pagamento associato.
        /// </summary>
        [Key, Column(Order = 1)]
        public int Tpgid_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta del tipo di pagamento.
        /// </summary>
        [StringLength(100)]
        public string Tpgid_Descrizione { get; set; }

        [ForeignKey("Tpgid_ID")]
        public virtual DbTipoPagamento TipoPagamento { get; set; }
    }
}