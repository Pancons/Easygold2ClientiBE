using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.Prodotti
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_listiniProdotto (Listini di Vendita).
    /// </summary>
    [Table("tbcl_listiniProdotto")]
    public class DbListiniProdotto : BaseDbEntity
    {
        [Key]
        public int Lis_IDAuto { get; set; }

        [Required, StringLength(100)]
        public string Lis_Descrizione { get; set; }

        [Required]
        public int Lis_Valuta { get; set; }

        [Required]
        public int Lis_TipoListino { get; set; }

        public bool Lis_Default { get; set; }

        public decimal? Lis_PercSconto { get; set; }

        public int? Lis_TipoArrotondamento { get; set; }

        public decimal? Lis_Arrotondamento { get; set; }

        public bool Lis_Annullato { get; set; }
    }
}