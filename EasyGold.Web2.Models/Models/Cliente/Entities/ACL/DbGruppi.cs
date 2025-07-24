using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_gruppi")] //
    public class DbGruppi : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Grp_IDAuto { get; set; }

        /// <summary>
        /// Campo Alfa 50 caratteri. È il nome del Gruppo.
        /// </summary>
        [StringLength(50)]
        public string Grp_NomeGruppo { get; set; }
        /// <summary>
        /// Campo Alfa 100 caratteri. È la descrizione estesa del Gruppo.
        /// </summary>
        [StringLength(100)]
        public string? Grp_DesGruppo { get; set; }
        /// <summary>
        /// Campo bit. Nella Form è un campo Check attivo solo se non esiste già un Gruppo SuperAmministratore. In tutti gli altri casi il campo non è visibile. Questo Gruppo viene creato in automatico quando si crea il DB del Cliente. Può esistere un solo Gruppo SuperAmministratore.
        /// </summary>
        public bool? Grp_SuperAdmin { get; set; }
        /// <summary>
        /// Campo bit nella Form è un campo Check. Se è selezionato il Gruppo e di conseguenza gli Utenti collegati sono bloccati. Gli Utenti appartenenti al Gruppo non potranno più fare il Login ad Easygold. Questo campo è abilitato solo se l’utente è “Admin” o “SuperAmministratore”.
        /// </summary>
        public bool? Grp_Bloccato { get; set; }

        public virtual ICollection<DbUtente> Utenti { get; set; } = new List<DbUtente>();
        public virtual ICollection<DbPermessiGruppo> PermessiGruppo { get; set; } = new List<DbPermessiGruppo>();
        public virtual ICollection<DbGruppiLang> GruppiLang { get; set; } = new List<DbGruppiLang>();
    }

 }
