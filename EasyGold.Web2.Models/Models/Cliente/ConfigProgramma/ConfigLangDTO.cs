using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;


namespace EasyGold.Web2.Models.Cliente.ConfigProgramma
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