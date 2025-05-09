using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbcl_gruppi")]
    public class DbGruppi : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Grp_IDAuto { get; set; }

        /// <summary>
        /// È il nome del Gruppo.
        /// </summary>
        [StringLength(50)]
        public string Grp_NomeGruppo { get; set; }
        /// <summary>
        /// È la descrizione estesa del Gruppo.
        /// </summary>
        [StringLength(100)]
        public string? Grp_DesGruppo { get; set; }
        /// <summary>
        /// Nella Form è un campo Check attivo solo se non esiste già un Gruppo SuperAmministratore. 
        /// </summary>
        public bool? Grp_SuperAdmin { get; set; }
        /// <summary>
        /// Se è selezionato il Gruppo e di conseguenza gli Utenti collegati sono bloccati
        /// </summary>
        public bool? Grp_Bloccato { get; set; }

    }
}