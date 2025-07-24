using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using EasyGold.Web2.Models.Cliente.ACL;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class UtenteDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Ute_IDAuto { get; set; }

        [SwaggerSchema(Description = "Codice alfanumerico per il Login ad Easygold.")]
        [Required, StringLength(30)]
        public string Ute_IDUtente { get; set; }

        [SwaggerSchema(Description = "Nome completo dell'Utente.")]
        [Required, StringLength(100)]
        public string Ute_NomeUtente { get; set; }

        [SwaggerSchema(Description = "Gruppo a cui l'Utente appartiene.")]
        [Required]
        public int Ute_IDGruppo { get; set; }

        [SwaggerSchema(Description = "Codice ISO della lingua scelta.")]
        [Required]
        public int Ute_IDIdioma { get; set; }

        [SwaggerSchema(Description = "Abilita l'accesso a tutti i negozi.")]
        public bool Ute_AbilitaTuttiNegozi { get; set; }

        [SwaggerSchema(Description = "Abilita l'accesso a CassaII, solo per Admin o SuperAmministratore.")]
        public bool Ute_AbilitaCassa { get; set; }

        [SwaggerSchema(Description = "Abilita l'eliminazione di prodotti, solo per Admin o SuperAmministratore.")]
        public bool Ute_AbilitaEliminaProd { get; set; }

        [SwaggerSchema(Description = "Blocca l'accesso dell'Utente.")]
        public bool Ute_Bloccato { get; set; }

        [SwaggerSchema(Description = "Blocca l'accesso dell'Utente.")]
        public string? Ute_PasswordResetToken { get; set; }

        [SwaggerSchema(Description = "Blocca l'accesso dell'Utente.")]
        public DateTime? Ute_ResetTokenExpiry { get; set; }

        [SwaggerSchema(Description = "Blocca l'accesso dell'Utente.")]
        public string? Ute_Email { get; set; }

            // Relazione con Negozi
        [SwaggerSchema(Description = "Lista dei negozi accessibili.")]
        public List<UtenteNegoziDTO> NegoziAccessibili { get; set; } = new List<UtenteNegoziDTO>();

        [SwaggerSchema(Description = "lista di pw utenti")]
        public List<PwUtentiDTO> PwUtenti { get; set; } = new List<PwUtentiDTO>();

        [SwaggerSchema(Description = "lista delle sessioni")]
        public List<SessioniEasyGoldDTO> Sessioni { get; set; } = new List<SessioniEasyGoldDTO>();      
    }
}
