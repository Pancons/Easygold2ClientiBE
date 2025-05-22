using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities


    [Table("tbco_ISONazioni")]
    public class DbNazioni
    {
        [Key]  // <- Definisce la chiave primaria
        public int Ntn_ISO1 { get; set; }

        [Required]
        [StringLength(255)]
        public string Ntn_Descrizione { get; set; }

    }
}