namespace EasyGold.API.Models.Entities.Nazioni
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tbco_ISONazioni")]
    public class DbNazioni
    {
        [Key]  // <- Definisce la chiave primaria
        public int Ntn_ISO1 { get; set; }

        [Required]
        [StringLength(255)]
        public string Ntn_Descrizione { get; set; }

    }
}