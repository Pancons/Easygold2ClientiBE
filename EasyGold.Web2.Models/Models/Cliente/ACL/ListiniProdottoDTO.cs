using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Listino di Vendita.
    /// </summary>
    public class ListiniProdottoDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale listino.")]
        public int Lis_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del listino.")]
        [StringLength(100)]
        public string Lis_Descrizione { get; set; }

        [SwaggerSchema(Description = "ID valuta.")]
        public int Lis_Valuta { get; set; }

        [SwaggerSchema(Description = "Tipo listino.")]
        public int Lis_TipoListino { get; set; }

        [SwaggerSchema(Description = "Listino di default.")]
        public bool Lis_Default { get; set; }

        [SwaggerSchema(Description = "Percentuale sconto (solo per listini sconto).")]
        public decimal? Lis_PercSconto { get; set; }

        [SwaggerSchema(Description = "Tipo arrotondamento (solo per listini sconto).")]
        public int? Lis_TipoArrotondamento { get; set; }

        [SwaggerSchema(Description = "Valore arrotondamento (solo per listini sconto).")]
        public decimal? Lis_Arrotondamento { get; set; }

        [SwaggerSchema(Description = "Listino annullato.")]
        public bool Lis_Annullato { get; set; }
    }
}