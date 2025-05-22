using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Tipo Metallo.
    /// </summary>
    public class TipiMetalloDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale tipo metallo.")]
        public int Tim_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del tipo metallo.")]
        [StringLength(100)]
        public string Tim_Descrizione { get; set; }

        [SwaggerSchema(Description = "Tipo metallo annullato.")]
        public bool Tim_Annullato { get; set; }
    }
}