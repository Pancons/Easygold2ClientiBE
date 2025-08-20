using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per le traduzioni dei tipi di pagamento.
    /// </summary>
    public class TipoPagamentoLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int Tpgid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID del tipo di pagamento associato.")]
        public int Tpgid_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione tradotta del tipo di pagamento.")]
        [StringLength(100)]
        public string Tpgid_Descrizione { get; set; }
    }
}