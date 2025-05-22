using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_aliquoteIVA_lang (traduzioni Aliquote IVA).
    /// </summary>
    [Table("tbcl_aliquoteIVA_lang")]
    public class DbAliquoteIVALang : BaseDbEntity
    {
        [Required]
        public int Ivaid_ISONum { get; set; }

        [Required]
        public int Ivaid_ID { get; set; }

        [StringLength(100)]
        public string Ivaid_Descrizione { get; set; }
    }
}