using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TabelleSempliciLangDTO
    {
        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int? TbsId_ISONum { get; set; }

        [SwaggerSchema(Description = "È il valore del campo tbs_IDAuto della tabella principale di cui è stata fatta la traduzione.")]
        public int? TbsId_ID { get; set; }

        [SwaggerSchema(Description = "È il testo inserito dall’Utente tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(100)]
        public string TbsId_Descrizione { get; set; }

    }
}
