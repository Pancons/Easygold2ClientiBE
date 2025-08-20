using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Condizioni di Pagamento.
    /// </summary>
    public class CodPagamentoDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale della condizione di pagamento.")]
        public int Cpa_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione della Condizione di Pagamento.")]
        [StringLength(100)]
        public string Cpa_Descrizione { get; set; }

        [SwaggerSchema(Description = "Mese di partenza per il pagamento.")]
        public int Cpa_PartenzaMese { get; set; }

        [SwaggerSchema(Description = "Numero di mesi del pagamento.")]
        public int Cpa_NumMesi { get; set; }

        [SwaggerSchema(Description = "Indica se si applica il calendario commerciale.")]
        public bool Cpa_MeseCommerciale { get; set; }

        [SwaggerSchema(Description = "Indica se la condizione di pagamento è annullata.")]
        public bool Cpa_Annullato { get; set; }

        [SwaggerSchema(Description = "Liste delle traduzioni della condizione di pagamento.")]
        public List<CodPagamentoLangDTO> Langs { get; set; } = new List<CodPagamentoLangDTO>();
    }
}