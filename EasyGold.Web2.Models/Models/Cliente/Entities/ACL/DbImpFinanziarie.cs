using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_impFinanziarie")]
    public class DbImpFinanziarie : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Imf_IDAuto { get; set; }

        /// <summary>
        /// Descrizione della Condizione di Pagamento.
        /// </summary>
        [StringLength(100)]
        public string Imf_Descrizione { get; set; }

        /// <summary>
        /// IBAN dell'impresa finanziaria.
        /// </summary>
        [StringLength(30)]
        public string Imf_IBAN { get; set; }

        /// <summary>
        /// BIC/Swift del conto corrente.
        /// </summary>
        [StringLength(30)]
        public string Imf_BIC { get; set; }

        /// <summary>
        /// Indica se l'impresa finanziaria è annullata.
        /// </summary>
        public bool Imf_Annullato { get; set; }

        /// <summary>
        /// Traduzioni dell'impresa finanziaria.
        /// </summary>
        public virtual ICollection<DbImpFinanziarieLang> ImpFinanziarieLang { get; set; } = new List<DbImpFinanziarieLang>();
    }
}