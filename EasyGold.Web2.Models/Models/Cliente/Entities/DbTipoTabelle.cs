using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_TipoTabelle_Lang")]
    public class dbTipoTabelle
    {
        /// <summary>
        /// Campo numerico intero auto
        /// </summary>
        [Key]
        public int Tit_IDAuto { get; set; }
        /// <summary>
        /// è il nome della tabella
        /// </summary>
        [StringLength(50)]
        public string Tit_Descrizione { get; set; }
        /// <summary>
        /// è il tipo della tabella
        /// </summary>
        public int? Tit_TipoTabella { get; set; }
    }
}