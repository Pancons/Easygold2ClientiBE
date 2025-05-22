using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
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