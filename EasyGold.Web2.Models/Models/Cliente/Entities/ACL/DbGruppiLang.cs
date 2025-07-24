using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_gruppi_lang")]

    public class DbGruppiLang : BaseDbEntity
    {
        /// <summary> 
        /// Campo Numerico Intero. È il codice ISO della lingua di cui sono stati tradotti i testi. Tabella dbo.tbco_idiomiEasygold campo idm_ISONum.
        /// </summary>
      
        public int grpid_ISONum { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
    
        public int grpid_ID { get; set; }

        /// <summary>
        /// Campo Testo 50 caratteri. È il nome del Gruppo tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(50)]
        public string grpid_nomeGruppo { get; set; }

        /// <summary>
        /// Campo Testo 100 caratteri. È il nome esteso del Gruppo tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string grpid_desGruppo { get; set; }

        [ForeignKey("grpid_ID")]
        public virtual DbGruppi Gruppi { get; set; }
    }
}