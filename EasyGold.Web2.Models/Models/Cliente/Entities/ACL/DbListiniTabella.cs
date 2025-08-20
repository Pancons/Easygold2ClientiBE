using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_listiniTabella")]
    public class DbListiniTabella : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Lst_IDAuto { get; set; }

        /// <summary>
        /// È la descrizione del Listino di Vendita a Tabella.
        /// </summary>
        [StringLength(100)]
        public string Lst_Descrizione { get; set; }

        /// <summary>
        /// Tipo Calcolo Listino a Tabella.
        /// </summary>
        public int Lst_TipoCalcolo { get; set; }

        /// <summary>
        /// Prezzo al Grammo per il tipo 1.
        /// </summary>
        public decimal Lst_PrezzoGrammo { get; set; }

        /// <summary>
        /// Moltiplicatore per il tipo 2 e 3.
        /// </summary>
        public decimal Lst_Moltiplicatore { get; set; }

        /// <summary>
        /// Moltiplicatore per il tipo 3 (per Manifattura).
        /// </summary>
        public decimal Lst_MoltipManifattura { get; set; }

        /// <summary>
        /// Se True, il valore è stato annullato.
        /// </summary>
        public bool Lst_Annullato { get; set; }

        public virtual ICollection<DbListiniTabellaLang> ListiniTabellaLang { get; set; } = new List<DbListiniTabellaLang>();
    }
}