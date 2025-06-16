using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    [Table("tbco_statoRegioniLang")]
    public class DbStatoRegioniLang : BaseDbEntity
    {
        [Required]
        public int StridISONum { get; set; }

        [Required]
        public int StridID { get; set; }

        [StringLength(200)]
        public string? StridDescrizione { get; set; }
    }
}
