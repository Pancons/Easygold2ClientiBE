using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Metalli
{
    [Table("tbcl_metalli")]
    public class DbMetalli
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Met_IDAuto { get; set; }

        /// <summary>
        /// Campo Testo 100 caratteri. È il metallo.
        /// </summary>
        [StringLength(100)]
        public string Met_Descrizione { get; set; }

        /// <summary>
        /// Campo bit. Indica se il metallo necessità di avere le quotazioni.
        /// </summary>
        public bool Met_Quotazione { get; set; }

        /// <summary>
        /// Campo bit. Indica se il metallo ha descrizione dettagliata.
        /// </summary>
        public bool Met_TipiMetallo { get; set; }

        /// <summary>
        /// Campo bit. Se True il metallo è stato annullato.
        /// </summary>
        public bool Met_Annullato { get; set; }

        public List<DbQuotazioneMetalli> Quotazioni { get; set; } = new List<DbQuotazioneMetalli>();
        public List<DbTipiMetallo> TipiMetallo { get; set; } = new List<DbTipiMetallo>();
        public virtual ICollection<DbMetalliLang> Traduzioni { get; set; } = new List<DbMetalliLang>();
    }
    }