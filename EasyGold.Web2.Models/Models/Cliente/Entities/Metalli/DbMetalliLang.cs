using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Metalli
{
    [Table("tbcl_metalli_lang")]
    public class DbMetalliLang
    {
        /// <summary>
        /// Campo Numerico Intero. È il codice ISO della lingua.
        /// </summary>
        public int MetID_ISONum { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il valore del campo Met_IDAuto della tabella principale.
        /// </summary>
        public int MetID_ID { get; set; }

        /// <summary>
        /// Campo Testo 100 caratteri. È il testo tradotto.
        /// </summary>
        [StringLength(100)]
        public string MetID_Descrizione { get; set; }

        /// <summary>
        /// Riferimento all'entità principale Metalli.
        /// </summary>
        [ForeignKey("MetID_ID")]
        public virtual DbMetalli Metallo { get; set; }
    }
}