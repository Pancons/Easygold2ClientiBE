using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{ 
    [Table("tbco_TabelleComuni_Lang")]
    public class DbTabelleComuniLang : BaseDbEntity
    {
        /// <summary>
        /// È il valore del campo tbc_IDAuto della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int TbcLng_ID { get; set; }

        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int? TbcLng_ISONum { get; set; }

        /// <summary>
        /// È il testo inserito tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string TbcLng_Descrizione { get; set; }


    }
}