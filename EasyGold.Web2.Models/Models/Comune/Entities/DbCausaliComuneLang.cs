using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_causali_lang")]
    public class DbCausaliComuneLang : BaseDbEntity
    {
        [Required]
        public int Cac_id_ISONum { get; set; }
        [Required]
        public int Cac_id_ID { get; set; }
        [StringLength(100)]
        public string Cac_id_Descrizione { get; set; }
    }
}