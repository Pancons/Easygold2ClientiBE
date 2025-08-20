using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_listiniTabella_lang")]
    public class DbListiniTabellaLang : BaseDbEntity
    {
        /// <summary>
        /// Codice ISO della lingua tradotta.
        /// </summary>
        public int Tbsid_ISONum { get; set; }

        /// <summary>
        /// Numero del record della tabella principale tradotto.
        /// </summary>
        public int Tbsid_ID { get; set; }

        /// <summary>
        /// Testo inserito dall’Utente tradotto nella lingua specificata.
        /// </summary>
        [StringLength(100)]
        public string Tbsid_Descrizione { get; set; }

        [ForeignKey("Tbsid_ID")]
        public virtual DbListiniTabella ListiniTabella { get; set; }
    }
}