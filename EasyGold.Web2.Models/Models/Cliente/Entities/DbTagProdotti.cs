using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    [Table("tbcl_tagProdotti")]
    public class DbTagProdotti
    {
        [Key]
        public int Etp_IDAuto { get; set; }

        [Required]
        [StringLength(100)]
        public string Etp_Descrizione { get; set; }

        [StringLength(16)]
        public string? Etp_ColEtichetta { get; set; }

        [StringLength(16)]
        public string? Etp_ColSfondo { get; set; }

        public int? Etp_TipoEtichetta { get; set; }

        public bool? Etp_InEvidenza { get; set; }

        public bool? Etp_Annullato { get; set; }
    }
}