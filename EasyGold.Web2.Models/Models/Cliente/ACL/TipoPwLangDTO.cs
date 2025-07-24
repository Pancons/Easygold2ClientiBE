using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TipoPwLangDTO
    {
        [SwaggerSchema(Description = "il codice ISO della lingua di cui sono stati tradotti i testi")]
        public int Tppid_ISONum { get; set; }

        [SwaggerSchema(Description = "È il numero del record della tabella principale di cui è stata fatta la traduzione")]
        public int Tppid_ID { get; set; }

        [SwaggerSchema(Description = "È il nome del Tipo Password tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(100)]
        public string Tppid_TipiPw { get; set; }
    }
}
