using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Anagrafiche
{
    public class DocumentiClienteDTO
    {
        [SwaggerSchema(Description = "ID univoco del documento cliente")]
        public int? Doc_IDAuto { get; set; }

        [Required]
        [SwaggerSchema(Description = "Codice ISO della nazione del cliente")]
        public int Doc_ISONum { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Intestazione del documento")]
        public string Doc_Documento { get; set; }

        [Required]
        [SwaggerSchema(Description = "Validità in anni del documento")]
        public int Doc_ValidoAnni { get; set; }

        [SwaggerSchema(Description = "Se true il documento è annullato")]
        public bool Doc_Annulla { get; set; }
    }
}