using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_province")]
    public class DbProvince : BaseDbEntity
    {
        /// <summary>
        /// È il codice dello Stato/Regione. 
        /// </summary>
        [Key]  // <- Definisce la chiave primaria
        public int Str_IDAuto { get; set; }
        /// <summary>
        /// È il numero ISO 3166 1 della Nazione. È il campo ntn_ISO1 della tabella dbo.tbco_ISONazioni
        /// </summary>
        public int? Str_ISO1 { get; set; }
        /// <summary>
        /// È la Provincia.
        /// </summary>
        [StringLength(200)]
        public string Str_Descrizione { get; set; }
        /// <summary>
        /// È la sigla della Provincia sulla targa dell’automobile
        /// </summary>
        [StringLength(20)]
        public string? Str_SiglaTargaAuto { get; set; }
        /// <summary>
        /// È il codice dello Stato/Regione a cui appartiene la Provincia
        /// </summary>
        public int? Str_CodStatoRegione { get; set; }

    }
}