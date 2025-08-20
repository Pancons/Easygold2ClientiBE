using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.Moduli
{
    public class ModuloDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del modulo")]
        public int Mdc_IDModulo { get; set; }

        [SwaggerSchema(Description = "Nome modulo su e-commerce")]
        [StringLength(50)]
        public string Mde_CodEcomm { get; set; }

        [Required]
        [StringLength(50)]
        [SwaggerSchema(Description = "Descrizione del modulo")]
        public string Mde_Descrizione { get; set; }

        [StringLength(400)]
        [SwaggerSchema(Description = "Descrizione estesa del modulo")]
        public string Mde_DescrizioneEstesa { get; set; }

    }
}
