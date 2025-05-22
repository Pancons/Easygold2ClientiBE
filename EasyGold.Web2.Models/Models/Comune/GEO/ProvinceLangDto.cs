using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO
{
    public class ProvinceLangDTO
    {
        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int? StrLng_ISONum { get; set; }

        [SwaggerSchema(Description = "È il numero del record della tabella principale di cui è stata fatta la traduzione")]
        public int? StrLng_ID { get; set; }

        [SwaggerSchema(Description = "È il nome della Provincia tradotto nella lingua della Nazione di cui al codice ISO")]
        [StringLength(200)]
        public string StrLng_Descrizione { get; set; }

    }
}
