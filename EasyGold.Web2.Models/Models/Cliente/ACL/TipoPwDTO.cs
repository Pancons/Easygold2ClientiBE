using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TipoPwDTO
    {
        [SwaggerSchema(Description = "Campo numerico auto")]
        public int Tpp_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il tipo di password che è inserita nella tabella delle password degli utenti.")]
        [StringLength(50)]
        public string Tpp_TipoPw { get; set; } 

        [SwaggerSchema(Description = "Lista dei permessi dei gruppi")]
        public List<PwUtentiDTO> PermessiGruppo { get; set; } = new List<PwUtentiDTO>();
    }
}
