using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class IdiomiSceltiDTO
    {
        /// <summary>
        /// Identificativo univoco per l'idioma.
        /// </summary>
        [SwaggerSchema(Description = "Identificativo univoco per l'idioma.")]
        public int Idm_IDAuto { get; set; }
        
        /// <summary>
        /// ID del cliente associato.
        /// </summary>
        [SwaggerSchema(Description = "ID del cliente associato.")]
        public int Idm_IDCliente { get; set; }

        /// <summary>
        /// ID dell'idioma scelto per il cliente.
        /// </summary>
        [SwaggerSchema(Description = "ID dell'idioma scelto per il cliente.")]
        public int Idm_IDIdioma { get; set; }
    }
}