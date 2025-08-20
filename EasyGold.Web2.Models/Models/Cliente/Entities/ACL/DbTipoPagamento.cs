using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_tipoPagamento")]
    public class DbTipoPagamento
    {
        /// <summary>
        /// ID auto-incrementale del tipo di pagamento.
        /// </summary>
        [Key]
        public int Tpg_IDAuto { get; set; }

        /// <summary>
        /// Descrizione del metodo di pagamento.
        /// </summary>
        [StringLength(100)]
        public string Tpg_Descrizione { get; set; }
        
        /// <summary>
        /// Tipo del pagamento.
        /// </summary>
        public int Tpg_Tipo { get; set; }

        /// <summary>
        /// Ordine di visualizzazione nella form di pagamento.
        /// </summary>
        public int Tpg_Ordinamento { get; set; }

        /// <summary>
        /// Indica se il tipo di pagamento è annullato.
        /// </summary>
        public bool Tpg_Annulla { get; set; }

        /// <summary>
        /// Traduzioni del tipo di pagamento.
        /// </summary>
        public virtual ICollection<DbTipoPagamentoLang> TipoPagamentoLang { get; set; } = new List<DbTipoPagamentoLang>();
    }
}