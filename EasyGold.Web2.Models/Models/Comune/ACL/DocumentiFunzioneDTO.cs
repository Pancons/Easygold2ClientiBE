using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per Documenti Funzione.
    /// </summary>
    public class DocumentiFunzioneDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale del documento della funzione.")]
        public int Dof_IDAuto { get; set; }

        [SwaggerSchema(Description = "Funzione associata.")]
        public int Dof_Funzione { get; set; }

        [SwaggerSchema(Description = "Codice ISO della nazione.")]
        public int Dof_ISONum { get; set; }

        [SwaggerSchema(Description = "Documento accettato.")]
        [StringLength(100)]
        public string Dof_Documento { get; set; }

        [SwaggerSchema(Description = "Tipo di documento.")]
        public int Dof_TipoDoc { get; set; }

        [SwaggerSchema(Description = "Sequenza di visualizzazione del documento.")]
        public int Dof_Sequenza { get; set; }

        [SwaggerSchema(Description = "Indica se il documento è annullato.")]
        public bool Dof_Annulla { get; set; }
    }
}