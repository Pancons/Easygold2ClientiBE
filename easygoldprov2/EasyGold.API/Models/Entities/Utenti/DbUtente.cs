using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyGold.API.Models.Entities.Ruoli;

namespace EasyGold.API.Models.Entities.Utenti
{
    public class DbUtente
    {
        [Key]  // <- Definisce la chiave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ute_IDUtente { get; set; }
        /// <summary>
        /// Stringa nome dell'utente.
        /// </summary>
        /// 
        public string Ute_Nome { get; set; }
        /// <summary>
        /// Stringa cognome dell'utente.
        /// </summary>
        /// 
        public string Ute_Cognome { get; set; }

        /// <summary>
        /// Stringa nomeutete 
        /// </summary>
        /// 
        [Required]
        [StringLength(100)]
        public string Ute_NomeUtente { get; set; }
        /// <summary>
        /// Intero  Ruolo dell'utente
        /// </summary>
        /// 
        public int Ute_IDRuolo { get; set; }
        /// <summary>
        /// Indica se l'utente è bloccato.
        /// </summary>
        /// 
        public bool Ute_Bloccato { get; set; }
        /// <summary>
        /// Nota sull'utente.
        /// </summary>
        /// 

        [StringLength(200)]
        public string Ute_Nota { get; set; }
        /// <summary>
        /// Passeword dell'utente.
        /// </summary>
        /// 
        [Required]
        public string Ute_Password { get; set; } // Password hashata

        [NotMapped]
        public DbRuolo? Ruolo { get; set; }  // ✅ Oggetto completo Ruolo


    }
}
