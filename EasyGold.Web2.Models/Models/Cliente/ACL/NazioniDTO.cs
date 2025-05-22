using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class NazioniDTO
    {

        [SwaggerSchema(Description = "Identificativo univoco della nazione")]
        public int Naz_id { get; set; }

        [StringLength(255)]
        [SwaggerSchema(Description = "Nome della nazione")]
        public string Naz_Nome { get; set; }

    }
}
