using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class CategorieLangDTO
    {
        [SwaggerSchema(Description = "È il valore del campo cat_IDAuto della tabella principale di cui è stata fatta la traduzione.")]
        public int CatId_ID { get; set; }

        [SwaggerSchema(Description = "È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int CatId_ISONum { get; set; }

        [SwaggerSchema(Description = "È la descrizione della categoria tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(100)]
        public string CatId_DescCategoria { get; set; }
    }
}
