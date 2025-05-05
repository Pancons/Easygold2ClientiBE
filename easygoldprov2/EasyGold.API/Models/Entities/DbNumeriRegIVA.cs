using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    /// <summary>
    /// Entità per la tabella dei numeri dei registri IVA.
    /// </summary>
    public class DbNumeriRegIVA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIDAuto { get; set; }

        [Required]
        public int RowIDRegIVA { get; set; }

        [Required]
        public int Nri_Anno { get; set; }

        [Required]
        public int Nri_NumFattura { get; set; }
    }
}