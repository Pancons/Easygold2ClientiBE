using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TabelleComuniLangDTO
    {
        [SwaggerSchema(Description = "È il valore del campo tbc_IDAuto della tabella principale di cui è stata fatta la traduzione.")]
        public int TbcLng_ID { get; set; }

        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int? TbcLng_ISONum { get; set; }

        [SwaggerSchema(Description = "È il testo inserito tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(100)]
        public string TbcLng_Descrizione { get; set; }
    }
}
