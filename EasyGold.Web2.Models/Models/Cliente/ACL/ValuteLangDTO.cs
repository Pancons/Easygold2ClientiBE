using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ValuteLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int Valid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del record principale della valuta tradotto.")]
        public int Valid_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione della valuta tradotta.")]
        [StringLength(100)]
        public string Valid_Descrizione { get; set; }
    }
}