using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbco_testataPostazioni_lang")]

    public class DbTestataPostazioniLang : BaseDbEntity
    {
        /// <summary> 
        /// Campo Numerico Intero. È il codice ISO della lingua di cui sono stati tradotti i testi. Tabella dbo.tbco_idiomiEasygold campo idm_ISONum.
        /// </summary>
     
        public int tpoid_ISONum { get; set; }
        /// <summary>
        /// Campo Numerico Intero. È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        public int tpoid_ID { get; set; }

        /// <summary>
        /// Campo Testo 50 caratteri. È il nome della Postazione tradotto nella lingua della Nazione di cui al codice ISO.
        /// </summary>
        [StringLength(50)]
        public string tpoid_Descrizione { get; set; }

    }
}