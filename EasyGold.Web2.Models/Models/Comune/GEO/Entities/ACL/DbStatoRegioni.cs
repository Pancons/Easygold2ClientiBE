using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_statoRegioni")]
    public class DbStatoRegioni
    {
        /// <summary>
        /// Numero ISO 3166 1 della Nazione.
        /// </summary>
        public int Str_ISO1 { get; set; }

        /// <summary>
        /// Codice unico dello Stato/Regione.
        /// </summary>
        [Key]
        public int Str_IDAuto { get; set; }

        /// <summary>
        /// Descrizione dello Stato/Nazione.
        /// </summary>
        [StringLength(200)]
        public string Str_Descrizione { get; set; }

        /// <summary>
        /// Codice del Capoluogo dello Stato/Regione.
        /// </summary>
        public int Str_CodCapoluogo { get; set; }

        /// <summary>
        /// Lista delle traduzioni associate per lo Stato/Regione.
        /// </summary>
        public List<DbIdStatoRegioni> IdStatoRegioni { get; set; } = new List<DbIdStatoRegioni>();
    }
}