using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbcl_tipopw_Lang")]
    public class dbtipoPwLang
    {
        /// <summary>
        /// il codice ISO della lingua di cui sono stati tradotti i testi
        /// </summary>
        public int Tppid_ISONum { get; set; }

        /// <summary>
        /// È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int Tppid_ID { get; set; }
        /// <summary>
        /// È il nome del Tipo Password tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string Tppid_TipiPw { get; set; }
    }
}