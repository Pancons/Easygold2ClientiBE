using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EasyGold.Web2.Models.Cliente.Entities {
    public class DbPietraPreziosa {
         [Key]
    public int Ppz_IdAuto { get; set; }

    [Required]
    [StringLength(100)]
    public string Ppz_Pietra { get; set; }

    public bool Ppz_Diamante { get; set; }

    public bool Ppz_Annulla { get; set; }
    }

   
}
