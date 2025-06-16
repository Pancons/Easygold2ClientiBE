using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Anagrafiche
{
    [Table("tbcl_negoziAltro")]
    public class DbNegoziAltro : BaseDbEntity
    {
        [Key]
        public int Nea_IDAuto { get; set; }

        [Required]
        public int Nea_IDNazione { get; set; }

        [Required]
        public int Nea_IDValuta { get; set; }

        [Required]
        public int Nea_IDListino { get; set; }

        [Required]
        public int Nea_IDAliquotaIVA { get; set; }
    }
}
