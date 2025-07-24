using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Entità per la tabella dbo.tbcl_utenteNegozi.
    /// </summary>
    [Table("tbcl_utenteNegozi")]//
    public class DbUtenteNegozi : BaseDbEntity
    {
       
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]

        public int Utn_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo ute_IDAuto della tabella dbo.tbcl_utenti.
        /// </summary>
        [Required]
        public int Utn_IDUtente { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo neg_IDAuto della tabella dbo.tbcl_negozi. Nella Form è un campo Combo a Selezione Singola con Ricerca. Deve visualizzare i valori della tabella dbo.tbcl_negozi.
        /// </summary>
        [Required]
        public int Utn_IDNegozio { get; set; }

        /// <summary>
        /// Campo Bit. Se a True l’Utente NON ha più accesso al Negozio.
        /// </summary>
        public bool Utn_Annullato { get; set; }

        /// <summary>
        /// Campo Bit. Nel caso di inserimento di più postazioni per lo stesso Utente/Negozio una postazione deve avere questo campo a True. Può esserci un’unica postazione Utente/Negozio che ha questo campo a True. Se si seleziona un’altra postazione Utente/Negozio questo campo dovrò essere messo a False in automatico.
        /// </summary>
        public bool Utn_Default { get; set; }

        [ForeignKey("Utn_IDUtente")]
        public virtual DbUtente Utente { get; set; }

        // Assuming DbNegozi is a defined entity
        [ForeignKey("Utn_IDNegozio")]
        public virtual DbNegozi Negozio { get; set; }

    }
}