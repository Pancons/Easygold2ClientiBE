using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TipoSKUDTO
    {
        [SwaggerSchema(Description = "ID Automatico.")]
        public int Sku_IDAuto { get; set; }

        [SwaggerSchema(Description = "Tipo di SKU.")]
        public int Sku_TipoSKU { get; set; }

        [SwaggerSchema(Description = "Valore indicato per la tabella SKU.")]
        [StringLength(20)]
        public string Sku_Valore { get; set; }

        [SwaggerSchema(Description = "Indica se il record è annullato.")]
        public bool Sku_Annullato { get; set; }
    }
}