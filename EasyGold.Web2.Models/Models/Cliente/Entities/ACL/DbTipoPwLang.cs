using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_tipopw_Lang")]
    public class DbTipoPwLang : BaseDbEntity
    {
        /// <summary>
        /// il codice ISO della lingua di cui sono stati tradotti i testi
        /// </summary>
        public int TppLng_ISONum { get; set; }

        /// <summary>
        /// È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int TppLng_ID { get; set; }
        /// <summary>
        /// È il nome del Tipo Password tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string TppLng_TipiPw { get; set; }
    }
}