using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_listiniProdotto_lang (traduzioni Listini di Vendita).
    /// </summary>
    [Table("tbcl_listiniProdotto_lang")]
    public class DbListiniProdottoLang : BaseDbEntity
    {
        [Required]
        public int Lisid_ISONum { get; set; }

        [Required]
        public int Lisid_ID { get; set; }

        [StringLength(100)]
        public string Lisid_Descrizione { get; set; }
    }
}