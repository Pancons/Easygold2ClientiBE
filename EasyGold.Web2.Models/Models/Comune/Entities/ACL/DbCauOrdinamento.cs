using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_cauOrdinamento")]
    public class DbCauOrdinamento
    {
        /// <summary>
        /// ID auto per l'ordinamento.
        /// </summary>
        [Key]
        public int Cao_IDAuto { get; set; }

        /// <summary>
        /// ID della causale per cui è definito l'ordinamento.
        /// </summary>
        public int Cao_ID { get; set; }

        /// <summary>
        /// Valore di ordinamento per la causale.
        /// </summary>
        public int Cao_Ordinamento { get; set; }

        [ForeignKey("Cao_ID")]
        public virtual DbCausaliComune CausaleComune { get; set; }

        /*[ForeignKey("Cao_ID")]
        public virtual DbCausali Causale { get; set; }*/
    }
}