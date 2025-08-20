using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_indirizzi_lang")]
    public class DbIndirizziLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int Strid_ISONum { get; set; }

        /// <summary>
        /// Numero del record della tabella principale a cui fa riferimento.
        /// </summary>
        public int Strid_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta dell'indirizzo.
        /// </summary>
        [StringLength(300)]
        public string Strid_Descrizione { get; set; }

        /// <summary>
        /// Riferimento all'entità Indirizzi.
        /// </summary>
        [ForeignKey("Strid_ID")]
        public virtual DbIndirizzi Indirizzo { get; set; }
    }
}