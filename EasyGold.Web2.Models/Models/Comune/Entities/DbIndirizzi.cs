using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_indirizzi")]
    public class DbIndirizzi : BaseDbEntity
    {
        /// <summary>
        /// È il codice della Località.  
        /// </summary>
        [Key]  // <- Definisce la chiave primaria
        public int Str_IDAuto { get; set; }
        /// <summary>
        /// È il numero ISO 3166 1 della Nazione. È il campo ntn_ISO1 della tabella dbo.tbco_ISONazioni. 
        /// </summary>
        public int? Str_ISO1 { get; set; }
        /// <summary>
        /// È l’indirizzo della Città.
        /// </summary>
        [StringLength(300)]
        public string Str_Descrizione { get; set; }
        /// <summary>
        /// È il codice della Località a cui appartiene l’indirizzo.
        /// </summary>
        public int? Str_CodLocalita { get; set; }
        /// <summary>
        /// È il CAP dell’indirizzo se diverso da quello della Località.
        /// </summary>
        [StringLength(10)]
        public string? Str_Cap { get; set; }   

    }
}