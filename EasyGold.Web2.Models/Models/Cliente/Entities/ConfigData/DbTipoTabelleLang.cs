using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{
    [Table("tbco_TipoTabelle_Lang")]
    public class DbTipoTabelleLang : BaseDbEntity
    {
        /// <summary>
        /// È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int TitLng_ID { get; set; }

        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int? TitLng_ISONum { get; set; }

        /// <summary>
        /// . È la descrizione del Tipo Tabella tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string TitLng_TipoTabella { get; set; }
    }
}