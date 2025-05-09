using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_statoRegioniLang")]
    public class DbStatoRegioneLang
    {
        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int? StrLng_ISONum { get; set; }
        /// <summary>
        /// È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int? StrLng_ID { get; set; }
        /// <summary>
        /// È il nome dello Stato/Nazione tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(200)]
        public string? StrLng_Descrizione { get; set; }
    } 
}