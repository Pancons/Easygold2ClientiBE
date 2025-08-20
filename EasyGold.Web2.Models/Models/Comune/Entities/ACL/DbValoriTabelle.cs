using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EasyGold.Web2.Models.Comune.Entities.ACL
{

    // Entity per tbco_ValoriTabelle
    [Table("tbco_ValoriTabelle")]
    public class DbValoriTabelle
    {
        [Key]
        public int rowId { get; set; }
        public DateTime? rowCreatedAt { get; set; }
        public DateTime? rowUpdatedAt { get; set; }
        public DateTime? rowDeletedAt { get; set; }
        public int? lst_oldId { get; set; }
        public string lst_description { get; set; }
        public string lst_itemType { get; set; }
    }

}