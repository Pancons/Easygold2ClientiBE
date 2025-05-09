using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbcl_categorie_lang")]
    public class DbCategorieLang : BaseDbEntity
    {
        /// <summary>
        /// È il valore del campo cat_IDAuto della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int CatLng_ID { get; set; }
        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int CatLng_ISONum { get; set; }

        /// <summary>
        /// È la descrizione della categoria tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string CatLng_DescCategoria { get; set; }
    }
}