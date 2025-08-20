using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_indirizzi")]
    public class DbIndirizzi : BaseDbEntity
    {
        /// <summary>
        /// Numero ISO 3166 1 della Nazione.
        /// </summary>
        public int Str_ISO1 { get; set; }

        /// <summary>
        /// Codice della Località.
        /// </summary>
        [Key]
        public int Str_IDAuto { get; set; }

        /// <summary>
        /// Indirizzo della Città.
        /// </summary>
        [StringLength(300)]
        public string Str_Descrizione { get; set; }

        /// <summary>
        /// Codice della Località a cui appartiene l'indirizzo.
        /// </summary>
        public int Str_CodLocalita { get; set; }

        /// <summary>
        /// CAP dell'indirizzo.
        /// </summary>
        [StringLength(10)]
        public string Str_CAP { get; set; }

        /// <summary>
        /// Collezione di traduzioni per l'indirizzo.
        /// </summary>
        public virtual ICollection<DbIndirizziLang> IndirizziLang { get; set; } = new List<DbIndirizziLang>();
    }
}