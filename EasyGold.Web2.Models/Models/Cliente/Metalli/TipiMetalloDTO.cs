using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Metalli
{
    public class TipiMetalloDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Tim_IDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il campo Met_IDAuto della tabella metalli.")]
        public int Tim_ID { get; set; }

        [SwaggerSchema(Description = "Campo Testo 100 caratteri. È la sottocategoria del metallo.")]
        [StringLength(100)]
        public string Tim_Descrizione { get; set; }

        [SwaggerSchema(Description = "Campo bit. Se True la sottocategoria del metallo è stata annullata.")]
        public bool Tim_Annullato { get; set; }

        [SwaggerSchema(Description = "Traduzioni disponibili per il tipo di metallo.")]
        public List<TipiMetalloLangDTO> Traduzioni { get; set; }
    }
}