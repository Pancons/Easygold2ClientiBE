using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities.Config
{
    /// <summary>
    /// Entità per la tabella delle traduzioni configurazione.
    /// </summary>
    [Table("syscl_configLang")]
    public class DbConfigLang
    {
        [Key, Column(Order = 0)]
        public int SysLng_ISONum { get; set; }

        public int SysLng_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string SysLng_NomeCampo { get; set; }
    }
}