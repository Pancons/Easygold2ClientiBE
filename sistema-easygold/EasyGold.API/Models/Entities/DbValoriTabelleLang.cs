using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{

    // Entity per tbco_ValoriTabelleLang
    [Table("tbco_ValoriTabelleLang")]
    public class DbValoriTabelleLang
    {
        [Key]
        public int rowId { get; set; }
        public DateTime? rowCreatedAt { get; set; }
        public DateTime? rowUpdatedAt { get; set; }
        public DateTime? rowDeletedAt { get; set; }
        public int lstl_itemId { get; set; }
        public int lstl_languageId { get; set; }
        public string lstl_description { get; set; }
    }

}