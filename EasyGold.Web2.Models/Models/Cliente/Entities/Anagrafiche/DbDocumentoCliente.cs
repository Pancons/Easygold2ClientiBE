using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.Anagrafiche
{

    public class DbDocumentoCliente
    {
        [Key]
        public int Doc_IdAuto { get; set; }

        public int Doc_ISONum { get; set; }

        [Required]
        [StringLength(100)]
        public string Doc_Documento { get; set; }

        public int Doc_ValidoAnni { get; set; }

        public bool Doc_Annulla { get; set; }
    }
}