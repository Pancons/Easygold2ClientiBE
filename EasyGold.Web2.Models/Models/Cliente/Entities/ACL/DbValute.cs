using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_valute")]
    public class DbValute
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Val_IDAuto { get; set; }

        /// <summary>
        /// Descrizione della valuta.
        /// </summary>
        [StringLength(100)]
        public string Val_Descrizione { get; set; }

        /// <summary>
        /// Valore di cambio rispetto alla valuta di default.
        /// </summary>
        public decimal Val_Cambio { get; set; }

        /// <summary>
        /// Numero di decimali da rappresentare.
        /// </summary>
        public int Val_NumDecimali { get; set; }

        /// <summary>
        /// Simbolo della valuta.
        /// </summary>
        [StringLength(3)]
        public string Val_SimboloValuta { get; set; }

        /// <summary>
        /// Sigla della valuta.
        /// </summary>
        [StringLength(3)]
        public string Val_SiglaValuta { get; set; }

        /// <summary>
        /// Se la valuta è stata annullata.
        /// </summary>
        public bool Val_Annullato { get; set; }

        /// <summary>
        /// Traduzioni associate alla valuta.
        /// </summary>
        public virtual ICollection<DbValuteLang> ValuteLang { get; set; } = new List<DbValuteLang>();
    }
}