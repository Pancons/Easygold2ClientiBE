using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigProdotto
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_tipiMetallo_lang (traduzioni Tipi Metallo).
    /// </summary>
    [Table("tbcl_tipiMetallo_lang")]
    public class DbTipiMetalloLang : BaseDbEntity
    {
        [Required]
        public int Timid_ISONum { get; set; }

        [Required]
        public int Timid_ID { get; set; }

        [StringLength(100)]
        public string Timid_Descrizione { get; set; }
    }
}