using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    public class StatoRegioni
    {
        public int StrIso1 { get; set; }
        public int StrIdAuto { get; set; }
        public string StrDescrizione { get; set; }
        public int? StrCodCapoluogo { get; set; }
    }
}
