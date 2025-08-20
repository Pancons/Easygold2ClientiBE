using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per la traduzione delle Condizioni di Pagamento.
    /// </summary>
    public class CodPagamentoLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        public int CpaId_ISONum { get; set; }

        [SwaggerSchema(Description = "ID della condizione di pagamento principale.")]
        public int CpaId_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione tradotta nella lingua specifica.")]
        [StringLength(100)]
        public string CpaId_Descrizione { get; set; }
    }
}