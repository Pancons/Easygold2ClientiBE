using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Tipo di Pagamento.
    /// </summary>
    public class TipoPagamentoDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale per il tipo di pagamento.")]
        public int Tpg_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del metodo di pagamento.")]
        [StringLength(100)]
        public string Tpg_Descrizione { get; set; }

        [SwaggerSchema(Description = "Tipo del pagamento.")]
        public int Tpg_Tipo { get; set; }

        [SwaggerSchema(Description = "Ordine di visualizzazione del pagamento.")]
        public int Tpg_Ordinamento { get; set; }

        [SwaggerSchema(Description = "Indica se il tipo di pagamento è annullato.")]
        public bool Tpg_Annulla { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni per il tipo di pagamento.")]
        public List<TipoPagamentoLangDTO> Traduzioni { get; set; } = new List<TipoPagamentoLangDTO>();
    }
}