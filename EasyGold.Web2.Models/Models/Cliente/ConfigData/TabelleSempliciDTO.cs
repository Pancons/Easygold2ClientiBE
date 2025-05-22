using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ConfigData
{
    public class TabelleSempliciDTO
    {
        [SwaggerSchema(Description = "Campo numerico intero Auto")]
        public int Tbs_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il valore del tipo della tabella del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle.")]
        public int? Tbs_IDTipo { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero Sequence.")]
        public int Tbs_ID { get; set; }

        [SwaggerSchema(Description = "È la descrizione del Tipo Tabella inserito dall’Utente.")]
        [StringLength(100)]
        public string Tbs_Descrizione { get; set; }
    }
}
