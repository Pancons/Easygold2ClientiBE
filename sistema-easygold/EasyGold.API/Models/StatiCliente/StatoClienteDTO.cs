using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.StatiCliente
{
    public class StatoClienteDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco dello stato")]
        public int Stc_id { get; set; }

        [StringLength(255)]
        [SwaggerSchema(Description = "Descrizione dello Stato")]
        public string Stc_Descrizione { get; set; }
    }
}
