using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    /// <summary>
    /// Entità per la tabella dei registri IVA.
    /// </summary>
    public class DbRegistroIVA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowIdAuto { get; set; }

        [Required]
        [StringLength(50)]
        public string Rgi_Descrizione { get; set; }

        [StringLength(10)]
        public string Rgi_Prefisso { get; set; }

        [StringLength(10)]
        public string Rgi_Suffisso { get; set; }

        public bool Rgi_Annulla { get; set; }
    }
}