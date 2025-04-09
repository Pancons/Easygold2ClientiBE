namespace EasyGold.API.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DbStatoCliente
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