using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_localita_lang")]
    public class DbLocalitaLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int Strid_ISONum { get; set; }

        /// <summary>
        /// Numero del record della tabella principale della Località.
        /// </summary>
        public int Strid_ID { get; set; }

        /// <summary>
        /// Nome tradotto della Località.
        /// </summary>
        [StringLength(200)]
        public string Strid_Descrizione { get; set; }

        /// <summary>
        /// Riferimento all'entità Località.
        /// </summary>
        [ForeignKey("Strid_ID")]
        public virtual DbLocalita Localita { get; set; }
    }
}