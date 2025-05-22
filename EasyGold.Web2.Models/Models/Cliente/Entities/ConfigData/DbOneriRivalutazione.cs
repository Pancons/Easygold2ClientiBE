using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{


    public class DbOneriRivalutazione
    {
        [Key]
        public int Onr_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        public string Onr_Modifica { get; set; }

        public decimal Onr_Fee { get; set; }

        public int Onr_Ordinamento { get; set; }

        public bool Onr_Annulla { get; set; }
    }
}