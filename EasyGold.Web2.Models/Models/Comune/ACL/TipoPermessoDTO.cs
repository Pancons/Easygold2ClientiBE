using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class TipoPermessoDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Tpa_IDAuto { get; set; }

        [SwaggerSchema(Description = "è la descrizione del permesso")]
        [StringLength(50)]
        public string Tpa_TipoPermesso { get; set; }

        [SwaggerSchema(Description = "È il livello del permesso può assumere 4 valori")]
        public int? Tpa_LivelloPermesso { get; set; }

        /*[SwaggerSchema(Description = "Lista dei permessi dei gruppi")]
        public List<PermessiGruppoDTO> PermessiGruppo { get; set; } = new List<PermessiGruppoDTO>();*/
    }
}
