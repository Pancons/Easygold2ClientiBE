using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.DTO.Config
{
    /// <summary>
    /// DTO per Configurazione Lingua.
    /// </summary>
    public class ConfigLangDTO
    {
        [Required]
        public int SysLng_ISONum { get; set; }

        [Required]
        public int SysLng_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string SysLng_NomeCampo { get; set; }
    }
}