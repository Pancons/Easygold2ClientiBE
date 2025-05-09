using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities
{
    [Table("tbcl_utenti")]
    public class DbUtenti : BaseDbEntity
    {
        /// <summary>
        /// Campo numero intero auto.  
        /// </summary>
        [Key]  // <- Definisce la chiave primaria
        public int Ute_IDAuto { get; set; }
        /// <summary>
        /// È il codice alfanumerico che l’Utente deve usare per fare il Login ad Easygold.
        /// </summary>
        [StringLength(30)]
        public string Ute_IDUtente { get; set; }
        /// <summary>
        /// È il nome esteso dell’Utente
        /// </summary>
        [StringLength(100)]
        public string Ute_NomeUtente { get; set; }
        /// <summary>
        /// è il gruppo a cui apparterrà l'utente.
        /// </summary>
        public int? Ute_IDGruppo { get; set; }
        /// <summary>
        /// È il codice ISO della lingua dell’Utente scelta fra quelle disponibili per l’azienda.
        /// </summary>
        public int? Ute_IDidioma { get; set; }

        /// <summary>
        /// Se è selezionato abilita l’Utente ad accedere a tutti i negozi del Cliente e ne abilita la scelta iniziale se non diversamente espresso nella “Postazione” del Computer.
        /// </summary>
        public bool? Ute_AbilitaTuttiNegozi { get; set; }
        /// <summary>
        /// Se è selezionato abilita l’Utente a CassaII. Questo campo è visibile e abilitato solo se l’utente è “Admin” o “SuperAmministratore”.
        /// </summary>
        public bool? Ute_AbilitaCassa {  get; set; }

        /// <summary>
        /// Se è selezionato abilita l’Utente a eliminare un prodotto e tutti i suoi movimenti
        /// </summary>
        public bool? Ute_AbilitaEliminaProd { get; set; }
        /// <summary>
        /// Se è selezionato abilita l’Utente a eliminare un prodotto e tutti i suoi moviment
        /// </summary>
        public bool? Ute_Bloccato { get; set; }

    }
}