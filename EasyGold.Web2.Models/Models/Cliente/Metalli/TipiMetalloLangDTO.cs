using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Metalli
{
    public class TipiMetalloLangDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero. È il codice ISO della lingua.")]
        public int TimID_ISONum { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il valore del campo Tim_IDAuto della tabella principale.")]
        public int TimID_ID { get; set; }

        [SwaggerSchema(Description = "Campo Testo 100 caratteri. Testo tradotto nella lingua della Nazione.")]
        [StringLength(100)]
        public string TimID_Descrizione { get; set; }
    }
}