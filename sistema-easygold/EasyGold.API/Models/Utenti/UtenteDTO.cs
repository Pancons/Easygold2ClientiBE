using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using EasyGold.API.Models.Ruoli;
using EasyGold.API.Models.Nazioni;
using System.Text.Json.Serialization;

namespace EasyGold.API.Models.Utenti
{
    public class UtenteDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco dell'utente")]
        public int? Ute_IDUtente { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Nome dell'utente")]
        public string Ute_Nome { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Cognome dell'utente")]
        public string Ute_Cognome { get; set; }

        [SwaggerSchema(Description = "Nome utente per l'accesso")]
        public string Ute_NomeUtente { get; set; }

        [SwaggerSchema(Description = "Identificativo del ruolo dell'utente")]
        public int Ute_IDRuolo { get; set; }

        [SwaggerSchema(Description = "Indica se l'utente è bloccato")]
        public bool Ute_Bloccato { get; set; }

        [StringLength(500)]
        [SwaggerSchema(Description = "Note aggiuntive sull'utente")]
        public string Ute_Nota { get; set; }

/*
        [Required]
        [SwaggerSchema(Description = "Password hashata dell'utente")]
        public string Ute_Password { get; set; }
*/

        /// <summary>
        /// Creo 2 oggetti Ruolo, per gestirne solo la serializzazione in output
        /// </summary>
        [SwaggerSchema(Description = "Dettaglio Ruolo dell'utente")]
        [JsonIgnore]
        public RuoloDTO? Ruolo { get; set; }

        [SwaggerSchema(Description = "Dettaglio Ruolo dell'utente")]
        [JsonPropertyName("ruolo")]
        public RuoloDTO? RuoloOutput => Ruolo;
    }
}
