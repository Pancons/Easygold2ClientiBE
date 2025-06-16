using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ConfigData
{
    [Table("tbcl_tipoPagamento")]
    public class DbTipoPagamento : BaseDbEntity
    {
        [Key]
        public int Tip_IdAuto { get; set; }

        [StringLength(100)]
        public string? Tip_Descrizione { get; set; }

        public bool Tip_Banca { get; set; }

        public bool Tip_Annullato { get; set; }
    }
}
