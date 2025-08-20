using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class AliQuoteIVADTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Iva_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione dell’aliquota IVA.")]
        [StringLength(100)]
        public string Iva_Descrizione { get; set; }

        [SwaggerSchema(Description = "Aliquota IVA da applicare ai movimenti.")]
        public decimal Iva_Aliquota { get; set; }

        [SwaggerSchema(Description = "Se l’aliquota è esente IVA.")]
        public bool Iva_Esenzione { get; set; }

        [SwaggerSchema(Description = "Se l’aliquota è scorporata.")]
        public bool Iva_Scorporata { get; set; }

        [SwaggerSchema(Description = "Check per vedere se è annullata.")]
        public bool Iva_Annullato { get; set; }

        [SwaggerSchema(Description = "Se l’aliquota IVA è stata assolta in uno stato estero.")]
        public bool Iva_Estero { get; set; }

        [SwaggerSchema(Description = "Natura IVA per Fattura Elettronica.")]
        public int Iva_NaturaFE { get; set; }

        [SwaggerSchema(Description = "Natura IVA per Scontrino.")]
        public int Iva_NaturaSC { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni associate all’aliquota IVA.")]
        public List<AliQuoteIVALangDTO> AliQuoteIVALang { get; set; } = new List<AliQuoteIVALangDTO>();
    }
}