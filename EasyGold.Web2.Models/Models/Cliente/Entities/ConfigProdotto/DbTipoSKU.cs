using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigProdotto
{


    public class DbTipoSKU
    {
        [Key]
        public int Sku_IdAuto { get; set; }

        public int Sku_TipoSKU { get; set; }

        [Required]
        [StringLength(20)]
        public string Sku_Valore { get; set; }

        public bool Sku_Annullato { get; set; }
    }
}