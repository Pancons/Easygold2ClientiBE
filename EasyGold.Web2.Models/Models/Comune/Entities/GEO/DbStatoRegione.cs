using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    [Table("tbco_statoRegioni")]
    public class DbStatoRegione : BaseDbEntity
    {
        /// <summary>
        /// È il codice dello Stato/Regione. 
        /// </summary>
        [Key]  // <- Definisce la chiave primaria
        public int Str_IDAuto { get; set; }
        /// <summary>
        /// È il numero ISO 3166 1 della Nazione
        /// </summary>
        public int? Str_ISO1 { get; set; }
        /// <summary>
        /// È lo Stato/Nazione.
        /// </summary>
        [StringLength(200)]
        public string Str_Descrizione { get; set; }
        /// <summary>
        /// È il codice del Capoluogo dello Stato/Regione
        /// </summary>
        public int? Str_CodCapoluogo { get; set; }
    }
}