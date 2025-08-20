using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Valute
{
    public class ValuteComuneDTO
    {

        [SwaggerSchema(Description = "Identificativo univoco della valuta")]
        public int? Val_id { get; set; }

        [StringLength(255)]
        [SwaggerSchema(Description = "Nome completo della Valuta")]
        public string? Val_Descrizione { get; set; }

        [Required]
        [SwaggerSchema(Description = "Tasso di cambio rispetto all'Euro")]
        public decimal? Val_Cambio { get; set; }

        [Required]
        [StringLength(3)]
        [SwaggerSchema(Description = "Simbolo della Valuta")]
        public string? Val_Simbolo { get; set; }

        [StringLength(3)]
        [SwaggerSchema(Description = "Simbolo della Valuta usato dai Registratori Fiscali")]
        public string? Val_SimboloRegCassa { get; set; }

        [Required]
        [SwaggerSchema(Description = "Numero di decimali utilizzati per rappresentare gli importi con quella valuta")]
        public int? Val_NumeroDecimali { get; set; }
    }
}
