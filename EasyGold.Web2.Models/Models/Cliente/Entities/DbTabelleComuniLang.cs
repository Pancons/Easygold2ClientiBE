using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_TabelleComuni_Lang")]
    public class dbTabelleComuniLang
    {
        /// <summary>
        /// È il valore del campo tbc_IDAuto della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        [Key]
        public int TbcId_ID { get; set; }

        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int? TbcId_ISONum { get; set; }

        /// <summary>
        /// È il testo inserito tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string TbcId_Descrizione { get; set; }


    }
}