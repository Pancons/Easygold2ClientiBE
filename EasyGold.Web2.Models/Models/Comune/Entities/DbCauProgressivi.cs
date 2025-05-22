using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_cauProgressivi")]
    public class DbCauProgressivi : BaseDbEntity
    {
        [Key]
        public int Cpr_IDAuto { get; set; }
        [StringLength(50)]
        public string Cpr_Descrizione { get; set; }
        public int Cpr_CalcGiacenza { get; set; }
        public int Cpr_CalcDisponibilita { get; set; }
        public bool Cpr_Annullato { get; set; }
    }
}