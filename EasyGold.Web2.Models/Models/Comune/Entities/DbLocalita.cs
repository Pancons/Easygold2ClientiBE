using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_localita")]
    public class DbLocalita : BaseDbEntity
    {
        /// <summary>
        /// È il codice della Località.  
        /// </summary>
        [Key]  // <- Definisce la chiave primaria
        public int Str_IDAuto { get; set; }
        /// <summary>
        /// È il numero ISO 3166 1 della Nazione. È il campo ntn_ISO1 della tabella dbo.tbco_ISONazioni
        /// </summary>
        public int? Str_ISO1 { get; set; }
        /// <summary>
        /// È la Località.
        /// </summary>
        [StringLength(200)]
        public string Str_Descrizione { get; set; }
        /// <summary>
        /// È il codice dello Stato/Regione a cui appartiene la Provincia. 
        /// </summary>
        public int? Str_CodStatoRegione { get; set; }
        /// <summary>
        /// Questo campo è inserito solo se la Nazione ha le Province altrimenti sarà a NULL
        /// </summary>
        public int? Str_CodProvincia { get; set; }
        /// <summary>
        /// È il CAP della Località se unico per tutti gli indirizzi.
        /// </summary>
        [StringLength(10)]
        public string? Str_Cap { get; set; }
    }
}