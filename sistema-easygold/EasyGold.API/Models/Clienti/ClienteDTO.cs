using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Clienti
{
    public class ClienteDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del cliente")]
        public int Utw_IDClienteAuto { get; set; }

        [Required]
        [StringLength(255)]
        [SwaggerSchema(Description = "Ragione sociale del cliente")]
        public string Dtc_RagioneSociale { get; set; }

        [StringLength(255)]
        [SwaggerSchema(Description = "Nome della gioielleria del cliente")]
        public string Dtc_Gioielleria { get; set; }

        [StringLength(255)]
        [SwaggerSchema(Description = "Nome del referente del cliente")]
        public string Dtc_Referente { get; set; }

        [Phone]
        [SwaggerSchema(Description = "Numero di telefono del cliente")]
        public string Dtc_Telefono { get; set; }

        [EmailAddress]
        [SwaggerSchema(Description = "Indirizzo email del cliente")]
        public string Dtc_Email { get; set; }

        [StringLength(100)]
        [SwaggerSchema(Description = "Città del cliente")]
        public string Dtc_Citta { get; set; }

        [StringLength(100)]
        [SwaggerSchema(Description = "Stato del cliente")]
        public string Dtc_Stato { get; set; }

        [SwaggerSchema(Description = "Indica se il cliente è attivo")]
        public bool Utw_Attivo { get; set; }

        [SwaggerSchema(Description = "Indica se il cliente è bloccato")]
        public bool Utw_Bloccato { get; set; }
    }
}
