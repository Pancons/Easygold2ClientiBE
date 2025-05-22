using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ConfigData 
{ 
    public class ValutaDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco della valuta")]
        public int Val_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione della valuta")]
        public string Val_Descrizione { get; set; }

        [SwaggerSchema(Description = "Valore di cambio rispetto alla valuta di default")]
        public decimal Val_Cambio { get; set; }

        [SwaggerSchema(Description = "Numero di decimali per i valori money")]
        public int Val_NumDecimali { get; set; }

        [Required]
        [StringLength(3)]
        [SwaggerSchema(Description = "Simbolo della valuta")]
        public string Val_SimboloValuta { get; set; }

        [Required]
        [StringLength(3)]
        [SwaggerSchema(Description = "Sigla della valuta")]
        public string Val_SiglaValuta { get; set; }

        [SwaggerSchema(Description = "Indica se la valuta è annullata")]
        public bool Val_Annullato { get; set; }
    }
}