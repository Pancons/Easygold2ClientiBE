using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Metalli
{
    [Table("tbcl_tipiMetallo")]
    public class DbTipiMetallo
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Tim_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo Met_IDAuto della tabella metalli.
        /// </summary>
        public int Tim_ID { get; set; }

        /// <summary>
        /// Campo Testo 100 caratteri. È la descrizione del tipo di metallo.
        /// </summary>
        [StringLength(100)]
        public string Tim_Descrizione { get; set; }

        /// <summary>
        /// Campo bit. Se True la sottocategoria è stata annullata.
        /// </summary>
        public bool Tim_Annullato { get; set; }

        /// <summary>
        /// Lista delle traduzioni per il tipo di metallo.
        /// </summary>
        public virtual ICollection<DbTipiMetalloLang> Traduzioni { get; set; }
    }
}