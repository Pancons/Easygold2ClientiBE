using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class UtentiDTO
    {
        [SwaggerSchema(Description = "Campo numero intero auto.")]
        public int Ute_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il codice alfanumerico che l’Utente deve usare per fare il Login ad Easygold.")]
        [StringLength(30)]
        public string Ute_IDUtente { get; set; }

        [SwaggerSchema(Description = " È il nome esteso dell’Utente")]
        [StringLength(100)]
        public string Ute_NomeUtente { get; set; }

        [SwaggerSchema(Description = "è il gruppo a cui apparterrà l'utente.")]
        public int? Ute_IDGruppo { get; set; }

        [SwaggerSchema(Description = "È il codice ISO della lingua dell’Utente scelta fra quelle disponibili per l’azienda.")]
        public int? Ute_IDidioma { get; set; }

        [SwaggerSchema(Description = "Se è selezionato abilita l’Utente ad accedere a tutti i negozi del Cliente e ne abilita la scelta iniziale se non diversamente espresso nella “Postazione” del Computer.")]
        public bool? Ute_AbilitaTuttiNegozi { get; set; }

        [SwaggerSchema(Description = "Se è selezionato abilita l’Utente a CassaII. Questo campo è visibile e abilitato solo se l’utente è “Admin” o “SuperAmministratore”.")]
        public bool? Ute_AbilitaCassa { get; set; }

        [SwaggerSchema(Description = "Se è selezionato abilita l’Utente a eliminare un prodotto e tutti i suoi movimenti")]
        public bool? Ute_AbilitaEliminaProd { get; set; }

        [SwaggerSchema(Description = "Se è selezionato abilita l’Utente a eliminare un prodotto e tutti i suoi moviment")]
        public bool? Ute_Bloccato { get; set; }
    }
}
