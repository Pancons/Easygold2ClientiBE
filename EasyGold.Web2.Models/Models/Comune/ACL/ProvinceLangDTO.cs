using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per la traduzione Provincia.
    /// </summary>
    public class ProvinceLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int StridISONum { get; set; }

        [SwaggerSchema(Description = "Numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int StridID { get; set; }

        [SwaggerSchema(Description = "Nome della Provincia tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(200)]
        public string StridDescrizione { get; set; }
    }
}