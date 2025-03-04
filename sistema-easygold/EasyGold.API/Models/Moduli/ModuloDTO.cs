using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Moduli
{
    public class ModuloDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del modulo")]
        public int Mdc_IDModulo { get; set; }

        [Required]
        [StringLength(255)]
        [SwaggerSchema(Description = "Descrizione del modulo")]
        public string Mde_Descrizione { get; set; }

        [StringLength(1000)]
        [SwaggerSchema(Description = "Descrizione estesa del modulo")]
        public string Mde_DescrizioneEstesa { get; set; }

        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "Data di attivazione del modulo")]
        public DateTime Mdc_DataAttivazione { get; set; }

        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "Data di disattivazione del modulo")]
        public DateTime Mdc_DataDisattivazione { get; set; }

        [SwaggerSchema(Description = "Indica se il modulo è bloccato")]
        public bool Mdc_BloccoModulo { get; set; }

        [DataType(DataType.DateTime)]
        [SwaggerSchema(Description = "Data e ora di blocco del modulo")]
        public DateTime Mdc_DataOraBlocco { get; set; }

        [StringLength(500)]
        [SwaggerSchema(Description = "Note aggiuntive sul modulo")]
        public string Mdc_Nota { get; set; }
    }
}
