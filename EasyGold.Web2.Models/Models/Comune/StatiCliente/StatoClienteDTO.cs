using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.StatiCliente
{
    public class StatoClienteDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco dello stato")]
        public int? Stc_id { get; set; }

        [StringLength(255)]
        [SwaggerSchema(Description = "Descrizione dello Stato")]
        public string? Stc_Descrizione { get; set; }

        [StringLength(10)]
        [SwaggerSchema(Description = "Colore dello Stato")]
        public string? Stc_Colore { get; set; }
    }
}
