using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_funzioni")]
    public class dbFunzioni
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Abl_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        public int Abl_IDPadre { get; set; }

        /// <summary>
        /// È la descrizione della Funzione di Easygold.
        /// </summary>
        [StringLength(50)]
        public string Abl_DescFunzione { get; set; }

        /// <summary>
        /// È la descrizione estesa della Funzione di Easygold.
        /// </summary>
        [StringLength(150)]
        public string Abl_DescFunzioneEstesa { get; set; }

        /// <summary>
        /// Check per vedere se è stato annullato
        /// </summary>
        public bool? Abl_Annullato { get; set; }
    }
}