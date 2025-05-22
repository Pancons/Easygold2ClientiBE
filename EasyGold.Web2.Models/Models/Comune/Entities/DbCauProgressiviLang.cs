using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_cauProgressivi_lang")]
    public class DbCauProgressiviLang : BaseDbEntity
    {
        [Required]
        public int Prcid_ISONum { get; set; }
        [Required]
        public int Prcid_ID { get; set; }
        [StringLength(50)]
        public string Prcid_Descrizione { get; set; }
    }
}