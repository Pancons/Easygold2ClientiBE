using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbco_causali")]
    public class DbCausaliComune : BaseDbEntity
    {
        [Key]
        public int Cac_IDAuto { get; set; }

        [Required, StringLength(100)]
        public string Cac_Descrizione { get; set; }

        [Required]
        public int Cac_IDDoveUso { get; set; }

        [Required]
        public int Cac_IDProgressivo { get; set; }

        [Required]
        public int Cac_IDtipoAnagrafica { get; set; }

        [Required]
        public int Cac_IDtipoIVA { get; set; }

        public bool Cac_Annulla { get; set; }
    }
}