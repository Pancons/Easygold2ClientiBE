using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.Anagrafiche
{
    public class NazioneNegozioDTO
    {
        [SwaggerSchema(Description = " ")]
        public int Nne_IDAuto { get; set; }

        [SwaggerSchema(Description = " ")]
        public int Nne_IDNegozio { get; set; }

        [SwaggerSchema(Description = " ")]
        public int Nne_IDTipoCampo { get; set; }

        [SwaggerSchema(Description = " ")]
        public string? Nne_Valore { get; set; }
    }
}
