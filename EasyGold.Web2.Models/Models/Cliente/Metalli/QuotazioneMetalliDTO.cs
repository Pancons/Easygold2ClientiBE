using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Cliente.Metalli
{
    public class QuotazioneMetalliDTO
    {
        [SwaggerSchema("Campo Numerico Intero Auto.")]
        public int mqt_IDAuto { get; set; }

        [SwaggerSchema("ID del metallo associato, corrisponde a met_IDAuto.")]
        public int mqt_ID { get; set; }

        [SwaggerSchema("Quotazione di acquisto del metallo.")]
        public decimal mqt_acquisto { get; set; }

        [SwaggerSchema("Quotazione di vendita fino per il metallo.")]
        public decimal mqt_venditaFino { get; set; }
    }
}