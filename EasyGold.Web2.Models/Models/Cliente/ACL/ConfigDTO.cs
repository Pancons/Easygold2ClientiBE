using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;


namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Configurazione.
    /// </summary>
    public class ConfigDTO
    {
        public int? Sys_IDAuto { get; set; }

        [Required]
        public string Sys_Sezione { get; set; }

        public int? Sys_IDNazione { get; set; }

        [Required]
        [StringLength(100)]
        public string Sys_NomeCampo { get; set; }

        [Required]
        public string Sys_TipoCampo { get; set; }

        public string? Sys_Valore { get; set; }

        public int? Sys_Lunghezza { get; set; }
    }
}