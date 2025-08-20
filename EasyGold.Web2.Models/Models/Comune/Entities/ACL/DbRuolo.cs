using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    public class DbRuolo : BaseDbEntity
    {
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ur_IDRuolo { get; set; }
        public string Ur_Descrizione { get; set; }
    }
}
