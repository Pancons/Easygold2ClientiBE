using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Comune.GEO
{
    public class IndirizziLangDTO
    {
        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int? StrLng_ISONum { get; set; }

        [SwaggerSchema(Description = "È il numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int? StrLng_ID { get; set; }

        [SwaggerSchema(Description = "È il nome dell’indirizzo tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(300)]
        public string StrLng_descrizione { get; set; }
    }
}
