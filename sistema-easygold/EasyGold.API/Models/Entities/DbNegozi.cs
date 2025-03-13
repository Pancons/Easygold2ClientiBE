namespace EasyGold.API.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DbNegozi
    {   
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Neg_id { get; set; }

        public int Neg_IDCliente { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Neg_RagioneSociale { get; set; }

        [Required]
        [StringLength(255)]
        public string Neg_NomeNegozio { get; set; }

        [DataType(DataType.Date)]
        public DateTime Neg_DataAttivazione { get; set; }

        [DataType(DataType.Date)]
        public DateTime Neg_DataDisattivazione { get; set; }

        public bool Neg_Bloccato { get; set; }

        [StringLength(500)]
        public string Neg_Note { get; set; }
    }
}