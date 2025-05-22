using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;


namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class EasyGold.Web2.Models.Cliente.ACL
    {
        [SwaggerSchema(Description = "Identificativo univoco della condizione di pagamento")]
        public int Cpa_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione della condizione di pagamento")]
        public string Cpa_Descrizione { get; set; }

        [SwaggerSchema(Description = "Partenza dal mese")]
        public int Cpa_PartenzaMese { get; set; }

        [SwaggerSchema(Description = "Numero mesi di pagamento")]
        public int Cpa_NumMesi { get; set; }

        [SwaggerSchema(Description = "Indica se si applica il calendario commerciale")]
        public bool Cpa_MeseCommerciale { get; set; }

        [SwaggerSchema(Description = "Indica se la condizione è annullata")]
        public bool Cpa_Annullato { get; set; }
    }
}