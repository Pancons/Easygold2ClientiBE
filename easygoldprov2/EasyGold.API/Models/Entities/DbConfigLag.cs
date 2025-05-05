using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    /// <summary>
    /// Entità per la tabella delle traduzioni configurazione.
    /// </summary>
    public class DbConfigLag
    {
        [Key, Column(Order = 0)]
        public int Sysid_ISONum { get; set; }

        public int Sysid_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Sysid_NomeCampo { get; set; }
    }
}