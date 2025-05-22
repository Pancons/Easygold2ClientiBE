using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities.ConfigData
{
    [Table("tbco_TabelleComuni")]
    public class DbTabelleComuni : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Tbc_IDAuto { get; set; }
        /// <summary>
        /// È il valore del tipo della tabella del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle.
        /// </summary>
        public int? Tbc_IDTipo { get; set; }

        /// <summary>
        /// Campo Numerico Intero Sequence.
        /// </summary>
        public int? Tbc_ID { get; set; }

        /// <summary>
        /// È la descrizione del record.
        /// </summary>
        [StringLength(100)]
        public string Tbc_Descrizione { get; set; }

    }
}