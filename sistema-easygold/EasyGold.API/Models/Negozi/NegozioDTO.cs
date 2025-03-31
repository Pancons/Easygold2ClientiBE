using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.Negozi
{
    public class NegozioDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del negozio")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [SwaggerSchema(Description = "Ragione sociale del negozio")]
        public string Neg_RagioneSociale { get; set; }

        [Required]
        [StringLength(255)]
        [SwaggerSchema(Description = "Nome del negozio")]
        public string Neg_NomeNegozio { get; set; }

        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "Data di attivazione del negozio")]
        public DateTime Neg_DataAttivazione { get; set; }

        [DataType(DataType.Date)]
        [SwaggerSchema(Description = "Data di disattivazione del negozio")]
        public DateTime Neg_DataDisattivazione { get; set; }

        [SwaggerSchema(Description = "Indica se il negozio è bloccato")]
        public bool Neg_Bloccato { get; set; }

        [DataType(DataType.DateTime)]
        [SwaggerSchema(Description = "Data e ora blocco del negozio")]
        public DateTime Neg_DataOraBlocco { get; set; }

        [StringLength(500)]
        [SwaggerSchema(Description = "Note aggiuntive sul negozio")]
        public string Neg_Note { get; set; }
    }
}
