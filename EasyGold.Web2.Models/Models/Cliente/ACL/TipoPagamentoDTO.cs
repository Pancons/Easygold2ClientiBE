using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EEasyGold.Web2.Models.Cliente.ACL
{
    public class TipoPagamentoDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del tipo di pagamento")]
        public int Tip_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione del tipo di pagamento")]
        public string Tip_Descrizione { get; set; }

        [SwaggerSchema(Description = "Indica se è un pagamento attraverso un'impresa finanziaria")]
        public bool Tip_Banca { get; set; }

        [SwaggerSchema(Description = "Indica se il tipo di pagamento è annullato")]
        public bool Tip_Annullato { get; set; }
    }
}