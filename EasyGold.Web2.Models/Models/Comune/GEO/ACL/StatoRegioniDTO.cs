using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.GEO.ACL
{
    public class StatoRegioniDTO
    {
        [SwaggerSchema(Description = "Numero ISO 3166 1 della Nazione.")]
        public int Str_ISO1 { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero Auto. È il codice dello Stato/Regione.")]
        public int Str_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione dello Stato/Nazione, fino a 200 caratteri.")]
        [StringLength(200)]
        public string Str_Descrizione { get; set; }

        [SwaggerSchema(Description = "Codice del Capoluogo dello Stato/Regione.")]
        public int Str_CodCapoluogo { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni associate per lo Stato/Regione.")]
        public List<IdStatoRegioniDTO> IdStatoRegioni { get; set; } = new List<IdStatoRegioniDTO>();
    }
}