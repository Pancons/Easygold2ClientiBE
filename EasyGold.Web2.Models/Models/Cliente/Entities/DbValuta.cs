using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    public class DbValuta
    {
        [Key]
        public int Val_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        public string Val_Descrizione { get; set; }

        public decimal Val_Cambio { get; set; }

        public int Val_NumDecimali { get; set; }

        [Required]
        [StringLength(3)]
        public string Val_SimboloValuta { get; set; }

        [Required]
        [StringLength(3)]
        public string Val_SiglaValuta { get; set; }

        public bool Val_Annullato { get; set; }
    }
}