using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using EasyGold.API.Models.Ruoli;
using EasyGold.API.Models.Nazioni;
using System.Text.Json.Serialization;

namespace EasyGold.API.Models.Utenti
{
    public class PasswordDTO
    {
        [Required]
        [SwaggerSchema(Description = "Identificativo univoco dell'utente")]
        public int Ute_IDUtente { get; set; }

        [Required]
        [SwaggerSchema(Description = "Vecchia Password dell'utente")]
        public string Ute_OldPassword { get; set; }

        [Required]
        [SwaggerSchema(Description = "Nuova Password dell'utente")]
        public string Ute_NewPassword { get; set; }
    }
}
