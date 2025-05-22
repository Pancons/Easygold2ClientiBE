using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    /// <summary>
    /// Entità per la tabella delle traduzioni configurazione.
    /// </summary>
    [Table("syscl_configLang")]
    public class DbConfigLang
    {
        [Key, Column(Order = 0)]
        public int SysLng_ISONum { get; set; }

        public int SysLng_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string SysLng_NomeCampo { get; set; }
    }
}