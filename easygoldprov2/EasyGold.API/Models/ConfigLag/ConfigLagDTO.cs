using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.ConfigLag
{
    /// <summary>
    /// DTO per Configurazione Lingua.
    /// </summary>
    public class ConfigLagDTO
    {
        [Required]
        public int Sysid_ISONum { get; set; }

        [Required]
        public int Sysid_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Sysid_NomeCampo { get; set; }
    }
}