using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{


    public class DbCreditCard
    {
        [Key]
        public int Crc_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        public string Crc_Card { get; set; }

        public decimal Crc_Fee { get; set; }

        public int Crc_Ordinamento { get; set; }

        public bool Crc_Annulla { get; set; }
    }
}