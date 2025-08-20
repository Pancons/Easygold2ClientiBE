using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Metalli
{
    [Table("tbcl_tipiMetallo_lang")]
    public class DbTipiMetalloLang
    {
        /// <summary>
        /// Campo Numerico Intero. È il codice ISO della lingua.
        /// </summary>
        public int TimID_ISONum { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il valore del campo Tim_IDAuto della tabella principale.
        /// </summary>
        public int TimID_ID { get; set; }

        /// <summary>
        /// Campo Testo 100 caratteri. Testo tradotto.
        /// </summary>
        [StringLength(100)]
        public string TimID_Descrizione { get; set; }

        /// <summary>
        /// Riferimento all'entità principale.
        /// </summary>
        [ForeignKey("TimID_ID")]
        public virtual DbTipiMetallo TipoMetallo { get; set; }
    }
}