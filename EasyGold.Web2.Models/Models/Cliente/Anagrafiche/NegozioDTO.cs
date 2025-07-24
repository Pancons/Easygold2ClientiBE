using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.Anagrafiche
{
    public class NegozioDTO
    {
        [SwaggerSchema(Description = " ")]
        public int Neg_id { get; set; }

        [SwaggerSchema(Description = " ")]
        public int Neg_IDCliente { get; set; }

        [SwaggerSchema(Description = " ")]
        [StringLength(255)]
        public string Neg_RagioneSociale { get; set; }

        [SwaggerSchema(Description = " ")]
        [StringLength(255)]
        public string Neg_NomeNegozio { get; set; }


        [SwaggerSchema(Description = " ")]
        public DateTime Neg_DataAttivazione { get; set; }

        [SwaggerSchema(Description = " ")]
        public DateTime? Neg_DataDisattivazione { get; set; }

        [SwaggerSchema(Description = " ")]
        public bool? Neg_Bloccato { get; set; }


        [SwaggerSchema(Description = " ")]
        public DateTime? Neg_DataOraBlocco { get; set; }


        [SwaggerSchema(Description = " ")]
        [StringLength(500)]
        public string? Neg_Note { get; set; }
    }
}