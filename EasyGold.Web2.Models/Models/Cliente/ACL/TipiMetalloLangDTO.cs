using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per la traduzione Tipo Metallo.
    /// </summary>
    public class TipiMetalloLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int Timid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del tipo metallo di cui è stata fatta la traduzione.")]
        public int Timid_ID { get; set; }

        [SwaggerSchema(Description = "Testo tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(100)]
        public string Timid_Descrizione { get; set; }
    }
}