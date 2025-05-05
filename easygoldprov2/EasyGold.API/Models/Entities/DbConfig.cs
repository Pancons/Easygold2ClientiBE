using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    /// <summary>
    /// Entità per la tabella di configurazione.
    /// </summary>
    public class DbConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sys_IDAuto { get; set; }

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