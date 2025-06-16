using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Anagrafiche
{
    [Table("tbcl_nazioneNegozio")]
    public class DbNazioneNegozio : BaseDbEntity
    {
        [Key]
        public int Nne_IDAuto { get; set; }

        [Required]
        public int Nne_IDNegozio { get; set; }

        [Required]
        public int Nne_IDTipoCampo { get; set; }

        [StringLength(200)]
        public string? Nne_Valore { get; set; }
    }
}
