using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class TipoPermessoLangDTO
    {
        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int? Tpaid_ISONum { get; set; }

        [SwaggerSchema(Description = "È il numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int? Tpaid_ID { get; set; }

        [SwaggerSchema(Description = "È il nome del tipo di abilitazione tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(50)]
        public string Tpaid_TipoAbilitazione { get; set; }
    }
}
