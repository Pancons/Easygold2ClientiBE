using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ClienteAbilitazioniDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto")]
        public int Abc_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il campo abl_IDAuto della tabella dbo.tbco_abilitazioni a cui si vuole attribuire una abilitazione")]
        public int Abc_IDAbilitazione { get; set; }

        [SwaggerSchema(Description = "È il valore del campo tpa_IDAuto della tabella dbo.tbco_tipoPermesso.")]
        public int? Abc_LivelloAbilitazione { get; set; }
    }
}
