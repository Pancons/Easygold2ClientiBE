
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Ruoli
{
    public class RuoloDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del ruolo")]
        public int Ur_IDRuolo { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione del ruolo")]
        public string Ur_Descrizione { get; set; }
    }
}
