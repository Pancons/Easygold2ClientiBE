using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ImpFinanziarieDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale dell'impresa finanziaria.")]
        public int Imf_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione della condizione di pagamento.")]
        [StringLength(100)]
        public string Imf_Descrizione { get; set; }

        [SwaggerSchema(Description = "IBAN dell'impresa finanziaria.")]
        [StringLength(30)]
        public string Imf_IBAN { get; set; }

        [SwaggerSchema(Description = "BIC/Swift del conto corrente.")]
        [StringLength(30)]
        public string Imf_BIC { get; set; }

        [SwaggerSchema(Description = "Indica se l'impresa finanziaria è annullata.")]
        public bool Imf_Annullato { get; set; }

        [SwaggerSchema(Description = "Lista di traduzioni per l'impresa finanziaria.")]
        public List<ImpFinanziarieLangDTO> Traduzioni { get; set; } = new List<ImpFinanziarieLangDTO>();
    }
}