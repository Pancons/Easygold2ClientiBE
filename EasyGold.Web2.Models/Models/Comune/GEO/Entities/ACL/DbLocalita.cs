using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_localita")]
    public class DbLocalita : BaseDbEntity
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
        /// Nome della Località.
        /// </summary>
        [StringLength(200)]
        public string Str_Descrizione { get; set; }

        /// <summary>
        /// Codice dello Stato/Regione a cui appartiene la Località.
        /// </summary>
        public int Str_CodStatoRegione { get; set; }

        /// <summary>
        /// Codice della Provincia a cui appartiene la Località.
        /// </summary>
        public int? Str_CodProvincia { get; set; }  // Nullable se non tutte le nazioni hanno province

        /// <summary>
        /// CAP della Località.
        /// </summary>
        [StringLength(10)]
        public string Str_CAP { get; set; }

        /// <summary>
        /// Collezione di traduzioni per la località.
        /// </summary>
        public virtual ICollection<DbLocalitaLang> LocalitaLang { get; set; } = new List<DbLocalitaLang>();
    }
}