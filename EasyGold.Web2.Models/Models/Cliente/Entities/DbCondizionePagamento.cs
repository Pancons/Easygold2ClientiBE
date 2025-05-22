
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{


    public class DbCondizionePagamento
    {
        [Key]
        public int Cpa_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        public string Cpa_Descrizione { get; set; }

        public int Cpa_PartenzaMese { get; set; }

        public int Cpa_NumMesi { get; set; }

        public bool Cpa_MeseCommerciale { get; set; }

        public bool Cpa_Annullato { get; set; }
    }
}