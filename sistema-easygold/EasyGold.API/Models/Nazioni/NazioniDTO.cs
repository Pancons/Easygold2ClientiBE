using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Nazioni
{
    public class NazioniDTO
    {

        [SwaggerSchema(Description = "Identificativo univoco del negozio")]
        public int Naz_id { get; set; }

        [StringLength(255)]
        [SwaggerSchema(Description = "Nome della nazione")]
        public string Naz_Nome { get; set; }
       
    }
}
