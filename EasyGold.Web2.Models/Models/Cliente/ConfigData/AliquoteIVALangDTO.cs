using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;


namespace EasyGold.Web2.Models.Cliente.ConfigData
{
    /// <summary>
    /// DTO per la traduzione Aliquota IVA.
    /// </summary>
    public class AliquoteIVALangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int Ivaid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID dell'aliquota di cui è stata fatta la traduzione.")]
        public int Ivaid_ID { get; set; }

        [SwaggerSchema(Description = "Testo tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(100)]
        public string Ivaid_Descrizione { get; set; }
    }
}