using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_tipoTagProdotti")]
    public class DbTipoTagProdotti
    {
        /// <summary>
        /// ID auto-incrementale del tipo di etichetta.
        /// </summary>
        [Key]
        public int Tpt_IDAuto { get; set; }

        /// <summary>
        /// Descrizione del tipo di etichetta.
        /// </summary>
        [StringLength(100)]
        public string Tpt_Descrizione { get; set; }

        /// <summary>
        /// Tipo TAG associato.
        /// </summary>
        public int Tpt_TipoTag { get; set; }

        /// <summary>
        /// Numero di giorni di visibilità per l'etichetta.
        /// </summary>
        public int? Tpt_NumGiorni { get; set; }
    }
}