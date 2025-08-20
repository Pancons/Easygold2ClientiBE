using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DbStatoCliente : BaseDbEntity
    {   
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Stc_id { get; set; }

        /// <summary>
        /// Descrizione dello Stato.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Stc_Descrizione { get; set; }

        /// <summary>
        /// Colore dello Stato.
        /// </summary>
        [StringLength(10)]
        public string? Stc_Colore { get; set; }
    }
}