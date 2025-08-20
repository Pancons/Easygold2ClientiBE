using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per la lingua di Carte di Pagamento.
    /// </summary>
    public class CreditCardLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        public int CrcId_ISONum { get; set; }

        [SwaggerSchema(Description = "ID della carta di credito principale.")]
        public int CrcId_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione del Pagamento tradotto.")]
        [StringLength(100)]
        public string CrcId_Brand { get; set; }
    }
}