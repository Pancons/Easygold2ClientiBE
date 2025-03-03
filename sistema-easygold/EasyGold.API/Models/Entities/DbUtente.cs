using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.API.Models.Entities
{
    public class DbUtente
    {
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ute_IDUtente { get; set; }
        public string Ute_Nome { get; set; }

        public string Ute_Cognome { get; set; }
        [Required]
        public string Ute_NomeUtente { get; set; }
        public int Ute_IDRuolo { get; set; }
        public bool Ute_Bloccato { get; set; }
        public string Ute_Nota { get; set; }
        [Required]
        public string Ute_Password { get; set; } // Password hashata



    }
}
