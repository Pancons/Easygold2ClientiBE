using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{


    public class DbImpresaFinanziaria
    {
        [Key]
        public int Imf_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        public string Imf_Descrizione { get; set; }

        [StringLength(30)]
        public string Imf_IBAN { get; set; }

        [StringLength(30)]
        public string Imf_BIC { get; set; }

        public bool Imf_Annullato { get; set; }
    }
}