using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Comune.ConfigData
{
    public class TipoTabelleLangDTO
    {
        [SwaggerSchema(Description = "È il numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int TitLng_ID { get; set; }

        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int? TitLng_ISONum { get; set; }

        [SwaggerSchema(Description = "È la descrizione del Tipo Tabella tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(100)]
        public string TitLng_TipoTabella { get; set; }
    }
}

