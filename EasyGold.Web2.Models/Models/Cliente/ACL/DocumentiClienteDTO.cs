using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Documenti Cliente.
    /// </summary>
    public class DocumentiClienteDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale del documento cliente.")]
        public int Doc_IDAuto { get; set; }

        [SwaggerSchema(Description = "Codice ISO della nazione del cliente.")]
        public int Doc_ISONum { get; set; }

        [SwaggerSchema(Description = "Documento accettato.")]
        [StringLength(100)]
        public string Doc_Documento { get; set; }

        [SwaggerSchema(Description = "Validità in anni del documento.")]
        public int Doc_ValidoAnni { get; set; }

        [SwaggerSchema(Description = "Indica se il documento è annullato.")]
        public bool Doc_Annulla { get; set; }
    }
}