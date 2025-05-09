using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbcl_tabelleSemplici")]
    public class dbTabelleSemplici
    {
        /// <summary>
        /// Campo numerico intero Auto
        /// </summary>
        [Key]
        public int Tbs_IDAuto { get; set; }

        /// <summary>
        /// . È il valore del tipo della tabella del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle.
        /// </summary>
        public int? Tbs_IDTipo { get; set; }

        /// <summary>
        /// Campo Numerico Intero Sequence.
        /// </suary>
        public int Tbs_ID { get; set; }

        /// <summary>
        /// È la descrizione del Tipo Tabella inserito dall’Utente.
        /// </summary>
        [StringLength(100)]
        public string Tbs_Descrizione { get; set; }

    }
}