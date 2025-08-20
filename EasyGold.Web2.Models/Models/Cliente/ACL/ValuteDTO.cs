using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ValuteDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto per l'ID della valuta.")]
        public int Val_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione della valuta.")]
        [StringLength(100)]
        public string Val_Descrizione { get; set; }

        [SwaggerSchema(Description = "Valore di cambio rispetto alla valuta di default.")]
        public decimal Val_Cambio { get; set; }

        [SwaggerSchema(Description = "Numero di decimali da rappresentare nei campi Money.")]
        public int Val_NumDecimali { get; set; }

        [SwaggerSchema(Description = "Simbolo della valuta.")]
        [StringLength(3)]
        public string Val_SimboloValuta { get; set; }

        [SwaggerSchema(Description = "Sigla della valuta.")]
        [StringLength(3)]
        public string Val_SiglaValuta { get; set; }

        [SwaggerSchema(Description = "Se la valuta è stata annullata.")]
        public bool Val_Annullato { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni associate alla valuta.")]
        public List<ValuteLangDTO> ValuteLang { get; set; } = new List<ValuteLangDTO>();
    }
}