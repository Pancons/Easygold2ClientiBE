using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbco_funzioni_lang")]
 
    public class DbFunzioniLang : BaseDbEntity
    {
        /// <summary> 
        /// È il valore del campo abl_IDAuto della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        
        public int Ablid_ID { get; set; }

        /// <summary>
        /// È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        public int? Ablid_ISONum { get; set; }

        /// <summary>
        /// È la descrizione dell’abilitazione tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(50)]
        public string Ablid_DescFunzione { get; set; }

        /// <summary>
        /// È la descrizione dell’abilitazione estesa tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(150)]
        public string Ablid_descFunzioneEstesa { get; set; }

        [ForeignKey("Ablid_ID")]
        public virtual DbFunzioni Funzione { get; set; }


    }
}