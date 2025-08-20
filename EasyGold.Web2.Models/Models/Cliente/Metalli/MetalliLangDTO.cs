using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Metalli
{
    public class MetalliLangDTO
    {
        [SwaggerSchema("Codice ISO della lingua della traduzione.")]
        public int metid_ISONum { get; set; }

        [SwaggerSchema("ID della traduzione, corrisponde a met_IDAuto.")]
        public int metid_ID { get; set; }

        [SwaggerSchema("Descrizione tradotta fino a 100 caratteri.")]
        [StringLength(100)]
        public string metid_descrizione { get; set; }
    }
}