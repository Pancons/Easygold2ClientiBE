using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TabelleComuni
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Tbc_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il valore del tipo della tabella del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle.")]
        public int? Tbc_IDTipo { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero Sequence.")]
        public int? Tbc_ID { get; set; }

        [SwaggerSchema(Description = "È la descrizione del record.")]
        [StringLength(100)]
        public string Tbc_Descrizione { get; set; }
    }
}
