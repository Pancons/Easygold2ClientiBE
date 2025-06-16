using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_cauOrdinamento")]
    public class DbCauOrdinamento : BaseDbEntity
    {
        [Key]
        public int Cao_IDAuto { get; set; }

        public int Cao_ID { get; set; }

        public int Cao_Ordinamento { get; set; }
    }
}
