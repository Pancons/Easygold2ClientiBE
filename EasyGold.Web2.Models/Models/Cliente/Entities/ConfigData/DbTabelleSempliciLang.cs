using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{
    [Table("tbcl_tabelleSemplici_Lang")]
    public class DbTabelleSempliciLang : BaseDbEntity
    {
        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int? TbsLng_ISONum { get; set; }

        /// <summary>
        /// È il valore del campo tbs_IDAuto della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int? TbsLng_ID { get; set; }

        /// <summary>
        /// È il testo inserito dall’Utente tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(100)]
        public string TbsLng_Descrizione { get; set; }

    }
}