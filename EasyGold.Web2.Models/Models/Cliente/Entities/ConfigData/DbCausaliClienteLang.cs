using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{
    [Table("tbcl_causali_lang")]
    public class DbCausaliClienteLang : BaseDbEntity
    {
        [Required]
        public int Cal_id_ISONum { get; set; }
        [Required]
        public int Cal_id_ID { get; set; }
        [StringLength(100)]
        public string Cal_id_Descrizione { get; set; }
    }
}