using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;


namespace EasyGold.Web2.Models.Cliente.ConfigData
{
    /// <summary>
    /// DTO per Aliquota IVA.
    /// </summary>
    public class AliquoteIVADTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale aliquota IVA.")]
        public int Iva_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione dell'aliquota IVA.")]
        [StringLength(100)]
        public string Iva_Descrizione { get; set; }

        [SwaggerSchema(Description = "Percentuale aliquota IVA.")]
        public decimal Iva_Aliquota { get; set; }

        [SwaggerSchema(Description = "Esenzione IVA.")]
        public bool Iva_Esenzione { get; set; }

        [SwaggerSchema(Description = "IVA scorporata.")]
        public bool Iva_Scorporata { get; set; }

        [SwaggerSchema(Description = "Aliquota annullata.")]
        public bool Iva_Annullato { get; set; }

        [SwaggerSchema(Description = "IVA estero.")]
        public bool Iva_Estero { get; set; }

        [SwaggerSchema(Description = "Natura FE.")]
        public int? Iva_NaturaFE { get; set; }

        [SwaggerSchema(Description = "Natura Scontrino.")]
        public int? Iva_NaturaSC { get; set; }
    }
}




