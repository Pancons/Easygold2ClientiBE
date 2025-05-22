using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ConfigProdotto
{
    public class TipoSKUDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco dello SKU")]
        public int Sku_IdAuto { get; set; }

        [SwaggerSchema(Description = "Tipo di SKU, riferisce a dbo.tbco_tabelleComuni")]
        public int Sku_TipoSKU { get; set; }

        [Required]
        [StringLength(20)]
        [SwaggerSchema(Description = "Valore indicato per la tabella SKU")]
        public string Sku_Valore { get; set; }

        [SwaggerSchema(Description = "Indica se lo SKU è annullato")]
        public bool Sku_Annullato { get; set; }
    }
}