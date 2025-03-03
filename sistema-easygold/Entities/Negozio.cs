namespace Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Negozio
    {
        public int Id { get; set; }

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
