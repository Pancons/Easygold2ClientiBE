using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per la traduzione Indirizzo.
    /// </summary>
    public class IndirizziLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int StridISONum { get; set; }

        [SwaggerSchema(Description = "Numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int StridID { get; set; }

        [SwaggerSchema(Description = "Nome dell’indirizzo tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(300)]
        public string StridDescrizione { get; set; }
    }
}