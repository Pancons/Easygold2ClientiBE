namespace EasyGold.API.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DbValute
    {   
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Val_id { get; set; }

        /// <summary>
        /// Nome completo della Valuta.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Val_Descrizione { get; set; }

        /// <summary>
        /// Tasso di cambio rispetto all'Euro
        /// </summary>
        [Required]
        public decimal Val_Cambio { get; set; }

        /// <summary>
        /// Simbolo della Valuta.
        /// </summary>
        [Required]
        [StringLength(3)]
        public string Val_Simbolo { get; set; }

        /// <summary>
        /// Simbolo della Valuta usato dai Registratori Fiscali.
        /// </summary>
        [StringLength(3)]
        public string? Val_SimboloRegCassa { get; set; }

        /// <summary>
        /// Numero di decimali utilizzati per rappresentare gli importi con quella valuta
        /// </summary>
        [Required]
        public int Val_NumeroDecimali { get; set; }
    }
}