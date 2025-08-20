// Easygold2BE/EasyGold.Web2.Models/Models/Cliente/Entities/ACL/DbCodPagamento.cs

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_codPagamento")]
    public class DbCodPagamento : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Cpa_IDAuto { get; set; }

        /// <summary>
        /// Descrizione della Condizione di Pagamento.
        /// </summary>
        [StringLength(100)]
        public string Cpa_Descrizione { get; set; }

        /// <summary>
        /// Mese di partenza per il pagamento.
        /// </summary>
        public int Cpa_PartenzaMese { get; set; }

        /// <summary>
        /// Numero di mesi del pagamento.
        /// </summary>
        public int Cpa_NumMesi { get; set; }

        /// <summary>
        /// Indica se si applica il calendario commerciale.
        /// </summary>
        public bool Cpa_MeseCommerciale { get; set; }

        /// <summary>
        /// Indica se la condizione di pagamento è annullata.
        /// </summary>
        public bool Cpa_Annullato { get; set; }

        public virtual ICollection<DbCodPagamentoLang> CodPagamentoLang { get; set; } = new List<DbCodPagamentoLang>();
    }
}