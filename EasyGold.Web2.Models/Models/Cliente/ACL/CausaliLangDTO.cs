using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class CausaliLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int Cal_id_ISONum { get; set; } // Usa "Cal_id_" per la lingua della tabella Cliente

        [SwaggerSchema(Description = "ID del record principale della causale tradotto.")]
        public int Cal_id_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione tradotta della causale.")]
        [StringLength(100)]
        public string Cal_id_Descrizione { get; set; }
    }
}