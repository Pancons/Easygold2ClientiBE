using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per la traduzione Località.
    /// </summary>
    public class LocalitaLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int StridISONum { get; set; }

        [SwaggerSchema(Description = "Numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int StridID { get; set; }

        [SwaggerSchema(Description = "Nome della Località tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(200)]
        public string StridDescrizione { get; set; }
    }
}