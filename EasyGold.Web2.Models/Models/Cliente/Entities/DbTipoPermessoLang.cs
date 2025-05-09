using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_tipoPermesso")]
    public class dbTipoPermessoLang
    {
        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int? Tpaid_ISONum  { get; set; }
        /// <summary>
        /// È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int? Tpaid_ID { get; set; }

        /// <summary>
        /// È il nome del tipo di abilitazione tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(50)]
        public string? Tpaid_TipoAbilitazione { get; set; }
    }
}