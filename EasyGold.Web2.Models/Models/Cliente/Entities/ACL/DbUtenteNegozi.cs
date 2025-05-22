using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_utenteNegozi.
    /// </summary>
    [Table("tbcl_utenteNegozi")]
    public class DbUtenteNegozi : BaseDbEntity
    {
        /// <summary>
        /// È il campo ute_IDAuto della tabella dbo.tbcl_utenti
        /// </summary>
        [Key]
        public int Utn_ID { get; set; }

        /// <summary>
        /// È il campo neg_IDAuto della tabella dbo.tbcl_negozi.
        /// </summary>
        [Required]
        public int Utn_IDNegozio { get; set; }

        /// <summary>
        /// Se a True l’Utente NON ha più accesso al Negozio.
        /// </summary>
        public bool? Utn_Annullato { get; set; }
    }
}