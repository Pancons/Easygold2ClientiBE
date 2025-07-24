using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using EasyGold.Web2.Models.Cliente.Entities.ACL;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_utenti")]//
    public class DbUtente
    {
        /// <summary>
        /// Campo Numerico Intero Auto. 
        /// </summary>
        [Key]
        public int Ute_IDAuto { get; set; }
        /// <summary>
        /// Campo Testo 30 caratteri. È il codice alfanumerico che l’Utente deve usare per fare il Login ad Easygold.
        /// </summary>
        [Required, StringLength(30)]
        public string Ute_IDUtente { get; set; }
        /// <summary>
        /// Campo Testo 100 caratteri. 
        /// </summary>
        [Required, StringLength(100)]
        public string Ute_NomeUtente { get; set; }
        /// <summary>
        /// Campo Numerico Intero. È il Gruppo a cui apparterrà l’Utente. Nella Form è un campo Combo a Selezione Singola con Ricerca. Deve visualizzare i valori della tabella dbo.tbcl_idiomiScelti.
        /// </summary>
        [Required]
        public int Ute_IDGruppo { get; set; }
        /// <summary>
        /// Campo Numerico Intero. È il codice ISO della lingua dell’Utente scelta fra quelle disponibili per l’azienda. 
        /// </summary>
        [Required]
        public int Ute_IDIdioma { get; set; }
        /// <summary>
        /// Campo bit. Nella Form è un campo Check. Se è selezionato abilita l’Utente ad accedere a tutti i negozi del Cliente e ne abilita la scelta iniziale se non diversamente espresso nella “Postazione” del Computer. Se al contrario è deselezionato nella Form si visualizzata una tabella con i Negozi “Attivi” dell’azienda (tabella dbo.tbcl_negozi). In ogni riga della tabella sarà selezionabile un campo Check. Se selezionato l’Utente accederà al negozio altrimenti non ne avrà accesso.
        /// </summary>
        public bool Ute_AbilitaTuttiNegozi { get; set; }
        /// <summary>
        /// Campo bit. Nella Form è un campo Check. Se è selezionato abilita l’Utente a CassaII. Questo campo è visibile e abilitato solo se l’utente è “Admin” o “SuperAmministratore”.
        /// </summary>
        public bool Ute_AbilitaCassa { get; set; }
        /// <summary>
        /// Campo bit. Nella Form è un campo Check. Se è selezionato abilita l’Utente a eliminare un prodotto e tutti i suoi movimenti. Questo campo è abilitato solo se l’utente è “admin” o “SuperAmministratore”.
        /// </summary>
        public bool Ute_AbilitaEliminaProd { get; set; }
        /// <summary>
        /// Campo bit. Nella Form è un campo Check. Se è selezionato l’Utente è bloccato e non potrà più fare il Login ad Easygold. Questo campo è abilitato solo se l’utente è “Admin” o “SuperAmministratore”.
        /// </summary>
        public bool Ute_Bloccato { get; set; }
        
        public string? Ute_PasswordResetToken { get; set; }
        public DateTime? Ute_ResetTokenExpiry { get; set; }
        public string? Ute_Email{ get; set; }
        public ICollection<DbRefreshToken> RefreshTokens { get; set; } = new List<DbRefreshToken>();

        public virtual DbGruppi Gruppo { get; set; } 
        public virtual ICollection<DbUtenteNegozi> UtenteNegozi { get; set; } = new List<DbUtenteNegozi>();
        public virtual ICollection<DbPwUtenti> PwUtenti { get; set; } = new List<DbPwUtenti>();
        public virtual ICollection<DbSessioniEasyGold> Sessioni { get; set; } = new List<DbSessioniEasyGold>();
        public virtual ICollection<DbUtentePostazione> UtentePostazioni { get; set; } = new List<DbUtentePostazione>();

    }
}
