using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ListiniProdottoLangDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero. È il codice ISO della lingua di cui sono stati tradotti i testi.")]
        public int Lisid_ISONum { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int Lisid_ID { get; set; }

        [SwaggerSchema(Description = "Campo Testo 100 caratteri. È il testo tradotto nella lingua della Nazione.")]
        [StringLength(100)]
        public string Lisid_Descrizione { get; set; }
    }
}