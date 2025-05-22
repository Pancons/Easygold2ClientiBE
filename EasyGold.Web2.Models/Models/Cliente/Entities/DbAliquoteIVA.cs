using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_aliquoteIVA (Aliquote IVA).
    /// </summary>
    [Table("tbcl_aliquoteIVA")]
    public class DbAliquoteIVA : BaseDbEntity
    {
        [Key]
        public int Iva_IDAuto { get; set; }

        [Required, StringLength(100)]
        public string Iva_Descrizione { get; set; }

        [Required]
        public decimal Iva_Aliquota { get; set; }

        public bool Iva_Esenzione { get; set; }
        public bool Iva_Scorporata { get; set; }
        public bool Iva_Annullato { get; set; }
        public bool Iva_Estero { get; set; }

        public int? Iva_NaturaFE { get; set; }
        public int? Iva_NaturaSC { get; set; }
    }
}