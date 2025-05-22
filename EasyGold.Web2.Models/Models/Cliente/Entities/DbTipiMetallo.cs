using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_tipiMetallo (Tipi Metallo).
    /// </summary>
    [Table("tbcl_tipiMetallo")]
    public class DbTipiMetallo : BaseDbEntity
    {
        [Key]
        public int Tim_IDAuto { get; set; }

        [Required, StringLength(100)]
        public string Tim_Descrizione { get; set; }

        public bool Tim_Annullato { get; set; }
    }
}