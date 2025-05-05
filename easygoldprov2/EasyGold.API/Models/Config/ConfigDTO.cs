using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Config
{
    /// <summary>
    /// DTO per Configurazione.
    /// </summary>
    public class ConfigDTO
    {
        public int? Sys_IDAuto { get; set; }

        [Required]
        public int Sys_Sezione { get; set; }

        [Required]
        public int Sys_Nazione { get; set; }

        [Required]
        [StringLength(100)]
        public string Sys_NomeCampo { get; set; }

        [Required]
        public int Sys_TipoCampo { get; set; }

        [Required]
        public string Sys_Valore { get; set; }

        public int Sys_Lunghezza { get; set; }
    }
}