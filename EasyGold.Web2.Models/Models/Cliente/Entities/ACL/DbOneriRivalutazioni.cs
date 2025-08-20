using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_oneriRivalutazioni")]
    public class DbOneriRivalutazioni : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Onr_IDAuto { get; set; }

        /// <summary>
        /// Intestazione della colonna.
        /// </summary>
        [StringLength(100)]
        public string Onr_Modifica { get; set; }

        /// <summary>
        /// Percentuale di aumento o diminuzione.
        /// </summary>
        public decimal Onr_Fee { get; set; }

        /// <summary>
        /// Ordinamento della colonna.
        /// </summary>
        public int Onr_Ordinamento { get; set; }

        /// <summary>
        /// Indica se l'onere o rivalutazione è annullata.
        /// </summary>
        public bool Onr_Annulla { get; set; }

        public virtual ICollection<DbOneriRivalutazioniLang> OneriRivalutazioniLang { get; set; } = new List<DbOneriRivalutazioniLang>();
    }
}