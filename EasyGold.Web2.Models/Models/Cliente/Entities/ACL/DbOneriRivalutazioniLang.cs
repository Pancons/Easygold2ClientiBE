using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_oneriRivalutazioni_lang")]
    public class DbOneriRivalutazioniLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int OnrId_ISONum { get; set; }

        /// <summary>
        /// ID dell'onere o rivalutazione principale.
        /// </summary>
        public int OnrId_ID { get; set; }

        /// <summary>
        /// Descrizione tradotta nella lingua specifica.
        /// </summary>
        [StringLength(100)]
        public string OnrId_Descrizione { get; set; }

        [ForeignKey("OnrId_ID")]
        public virtual DbOneriRivalutazioni OneriRivalutazioni { get; set; }
    }
}