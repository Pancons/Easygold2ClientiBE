using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.Anagrafiche
{
    public class ImpresaFinanziariaDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco dell'impresa finanziaria")]
        public int Imf_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione dell'impresa finanziaria")]
        public string Imf_Descrizione { get; set; }

        [StringLength(30)]
        [SwaggerSchema(Description = "IBAN dell'impresa finanziaria")]
        public string Imf_IBAN { get; set; }

        [StringLength(30)]
        [SwaggerSchema(Description = "BIC/SWIFT dell'impresa finanziaria")]
        public string Imf_BIC { get; set; }

        [SwaggerSchema(Description = "Indica se l'impresa finanziaria è annullata")]
        public bool Imf_Annullato { get; set; }
    }
}