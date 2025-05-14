using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    [Table("tbcl_documentiCliente")]
    public class DbDocumentiCliente
    {
        [Key]
        public int Doc_IDAuto { get; set; }

        [Required]
        public int Doc_ISONum { get; set; }

        [Required]
        [StringLength(100)]
        public string Doc_Documento { get; set; }

        [Required]
        public int Doc_ValidoAnni { get; set; }

        [Required]
        public bool Doc_Annulla { get; set; }
    }
}