using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class AliQuoteIVALangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int Ivaid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del record principale dell’aliquota IVA tradotto.")]
        public int Ivaid_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione dell’aliquota IVA tradotta.")]
        [StringLength(100)]
        public string Ivaid_Descrizione { get; set; }
    }
}