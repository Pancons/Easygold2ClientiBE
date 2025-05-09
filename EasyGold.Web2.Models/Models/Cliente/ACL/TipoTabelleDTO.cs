using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TipoTabelleDTO
    {
        [SwaggerSchema(Description = "Campo numerico intero auto")]
        public int Tit_IDAuto { get; set; }

        [SwaggerSchema(Description = "è il nome della tabella")]
        [StringLength(50)]
        public string Tit_Descrizione { get; set; }

        [SwaggerSchema(Description = "è il tipo della tabella")]
        public int? Tit_TipoTabella { get; set; }
    }
}

