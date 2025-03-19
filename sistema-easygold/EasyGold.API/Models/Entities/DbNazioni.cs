namespace EasyGold.API.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DbNazioni
    {   
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Naz_id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Naz_Nome { get; set; }

    }
}