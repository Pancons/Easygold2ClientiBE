using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Brand
{
    public class BrandLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        public int BrdId_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del brand principale.")]
        public int BrdId_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione del Brand tradotto.")]
        [StringLength(100)]
        public string BrdId_Brand { get; set; }
    }
}